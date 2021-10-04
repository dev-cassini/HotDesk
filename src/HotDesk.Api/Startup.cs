using HotDesk.Api.Tooling;
using HotDesk.Api.Tooling.Authorisation;
using HotDesk.Api.Tooling.Configuration;
using HotDesk.Api.Tooling.Swagger;
using HotDesk.Domain.Tooling;
using HotDesk.Infrastructure;
using HotDesk.Infrastructure.Tooling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace HotDesk.Api
{
    public class Startup
    {
        private readonly CorsConfiguration _corsConfiguration;
        private readonly IdentityServerConfiguration _identityServerConfiguration;
        private readonly ServiceInstanceConfiguration _serviceInstanceConfiguration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _corsConfiguration = configuration.GetSection("Cors").Get<CorsConfiguration>();
            _identityServerConfiguration = configuration.GetSection("IdentityServer").Get<IdentityServerConfiguration>();
            _serviceInstanceConfiguration = configuration.Get<ServiceInstanceConfiguration>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = _serviceInstanceConfiguration.ServiceName,
                    Version = _serviceInstanceConfiguration.Version
                });
                
                c.CustomSchemaIds(s => s.FullName);
                c.UseInlineDefinitionsForEnums();

                if (_identityServerConfiguration.RequiresAuthentication)
                {
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            ClientCredentials = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri($"{_identityServerConfiguration.Url}/connect/token"),
                                Scopes = new Dictionary<string, string>
                            {
                                {
                                    _identityServerConfiguration.HotDeskApiAdminScope,
                                    "Hot Desk API read and write access."
                                }
                            }
                            }
                        }
                    });
                }

                if (_identityServerConfiguration.RequiresAuthorisation)
                {
                    c.OperationFilter<AuthoriseCheckOperationFilter>();
                }

                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{_serviceInstanceConfiguration.ServiceName}.xml");
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                };
            });

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
                {
                    c.Authority = _identityServerConfiguration.Url;
                    c.RequireHttpsMetadata = _identityServerConfiguration.RequiresHttps;
                    c.Audience = _identityServerConfiguration.Audience;
                    c.TokenValidationParameters.ValidateAudience = _identityServerConfiguration.ValidateAudience;
                    c.TokenValidationParameters.ValidIssuer = _identityServerConfiguration.Url;
                });
            
            services.AddAuthorization(c =>
            {
                c.AddPolicy(
                    Policies.AdministrationPolicy,
                    policy => policy.RequireClaim("scope", _identityServerConfiguration.HotDeskApiAdminScope));
            });

            services.AddCors();

            services.AddDbContext<HotDeskDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString"), sqlServerOptions =>
                {
                    sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                });
            });

            services.AddHttpContextAccessor();
            services.AddHotDeskApiServices();
            services.AddHotDeskDomainServices();
            services.AddHotDeskInfrastructureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"HotDesk.Api {_serviceInstanceConfiguration.Version}");
                c.OAuthClientId(_identityServerConfiguration.SwaggerClientId);
                c.OAuthAppName(_serviceInstanceConfiguration.ServiceName);
                c.OAuthUsePkce();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            if (_identityServerConfiguration.RequiresAuthentication)
            {
                app.UseAuthentication();
            }

            if (_identityServerConfiguration.RequiresAuthorisation)
            {
                app.UseAuthorization();
            }

            app.UseCors(policy =>
            {
                policy.WithOrigins(_corsConfiguration.AllowedOrigins.ToArray());
                policy.SetIsOriginAllowedToAllowWildcardSubdomains();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

            app.UseEndpoints(endpoints =>
            {
                var controllerEndpoints = endpoints.MapControllers();

                if (_identityServerConfiguration.RequiresAuthorisation)
                {
                    controllerEndpoints.RequireAuthorization();
                }
            });
        }
    }
}
