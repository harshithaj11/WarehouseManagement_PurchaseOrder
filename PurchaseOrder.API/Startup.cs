using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PurchaseOrder.Domain.Aggregates.PurchaseOrderAggregate;
using PurchaseOrder.Domain.Interfaces;
using PurchaseOrder.Domain.Services;
using PurchaseOrder.Infrastructure.Data;
using PurchaseOrder.Infrastructure.Data.Context;
using PurchaseOrder.Infrastructure.Repositories;
using PurchaseOrder.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PurchaseOrder.Domain.DomainEvents;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PurchaseOrder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddMediatR(typeof(EventBase));
            services.AddControllers();
            services.AddDbContext<PurchaseOrdContext>(setup => setup.UseSqlServer(connectionString));
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IRepository<PurchaseOrd>, Repository<PurchaseOrd>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Purchase Order API",
                    Description = "Allows working with Purchase Order information in database",
                    TermsOfService = new Uri("http://www.cognizant.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Harshitha",
                        Email = "j.harshitha111@gmail.com",
                        Url = new Uri("https://github.com/harshithaj11")
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                    In = ParameterLocation.Header,
                    Description = "Jwt token for authorized user"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {new OpenApiSecurityScheme(){Reference=new OpenApiReference{ Id="Bearer", Type=ReferenceType.SecurityScheme}}, new string[]{ } }
                });
            });
            string key = Configuration["JwtSettings:key"];
            string issuer = Configuration["JwtSettings:issuer"];
            string audience = Configuration["JwtSettings:audience"];

            //convert string to byte array (include namespace System.Text)
            byte[] keybytes = Encoding.ASCII.GetBytes(key);

            //encode bytes to sign in key (include Microsoft.IdentityModel.Tokens).Use this key to generate signature to verify jwt tokwn from tampering
            SecurityKey securitykey = new SymmetricSecurityKey(keybytes);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;

                //specify type of token as jwt and configure it .The following are verified when client sends a request
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,

                    IssuerSigningKey = securitykey, //from this key we generate signature and verify jwt with it
                    ValidIssuer = issuer,
                    ValidAudience = audience

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();   //accept request from all client
                options.AllowAnyMethod();   //support all http operations like get, post, put, delete
                options.AllowAnyHeader();   //support all http headers like content-type, accept, etc
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Purchase Order API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
            AppDbInitializer.Seed(app);
        }

    }
}
