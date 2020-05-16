using Autofac;

using Bread.Common.Options;
using Bread.Data;
using Bread.DependencyInjection;
using Bread.Security;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System;
using System.Text;

namespace Bread.WebApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = 
                new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddDbContext<BreadDbContext>(
                    options =>
                        options.UseSqlServer(Configuration.GetSection("ConnectionString:BreadDb").Value)
                );

            ConfigureJsonWebToken(services);

            services
                .Configure<SecurityOptions>(config => Configuration.GetSection("Security").Bind(config));

            services
                .AddAuthorization(config =>
                {
                    config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                    config.AddPolicy(Policies.User, Policies.UserPolicy());
                });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction
                    .SwaggerDoc("v1", new OpenApiInfo { Title = "Bread API", Version = "v1" });
            });
        }

        private void ConfigureJsonWebToken(IServiceCollection services)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Security:Jwt:Issuer"],
                ValidAudience = Configuration["Security:Jwt:Audience"],
                IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Security:Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            CompositionRoot.RegisterAssemblyModules(builder);                       
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureSwagger(app);

            ConfigureWebApi(app);
        }        

        private static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bread API V1");
            });
        }

        private static void ConfigureWebApi(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
