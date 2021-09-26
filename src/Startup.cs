using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PlanthorWebApiServer.Context;

namespace PlanthorWebApiServer
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
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlanthorWebApiServer", Version = "v1" });
                
                // Include 'SecurityScheme' to use JWT Authentication
                c.AddSecurityDefinition(
                    "oauth",
                    new OpenApiSecurityScheme
                    {
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            {
                                Scopes = new Dictionary<string, string>
                                {
                                    ["api"] = "api scope description"
                                },
                                TokenUrl = new Uri("https://demo.identityserver.io/connect/token"),
                            },
                        },
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization,
                        Type = SecuritySchemeType.OAuth2
                    });
                    
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                    { 
                                        Type = ReferenceType.SecurityScheme, Id = "oauth" 
                                    },
                            },
                            new[] { "api" }
                        }
                    });  
            });

            IConfigurationRoot configuration = InitialConfigurationFiles();

            services.AddDbContext<PlanthorDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("MainPlanthorPostgresql")).EnableSensitiveDataLogging(true);
            });


            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "planthorwebapi");
                });
            });
        }

        private static IConfigurationRoot InitialConfigurationFiles()
        {
            return new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile("appsettings.Development.json", optional: true)
                        .Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlanthorWebApiServer v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope");
            });
        }
    }
}
