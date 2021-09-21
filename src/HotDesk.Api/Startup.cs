using HotDesk.Api.Tooling.StartupTasks;
using HotDesk.Api.Tooling.StartupTasks.Common;
using HotDesk.Domain.Tooling;
using HotDesk.Infrastructure;
using HotDesk.Infrastructure.Tooling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HotDesk.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotDesk.Api", Version = "v1" });
            });

            services.AddDbContext<HotDeskDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString"), sqlServerOptions =>
                {
                    sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                });
            });

            services.AddHttpContextAccessor();
            services.AddHotDeskDomainServices();
            services.AddHotDeskInfrastructureServices();

            services.AddTransient<MigrateDatabaseStartupTask>();
            services.AddTransient<DataSeederStartupTask>();
            services.AddTransient<IAsyncStartupTask, ScopedAsyncStartupTask<MigrateDatabaseStartupTask>>();
            services.AddTransient<IAsyncStartupTask, ScopedAsyncStartupTask<DataSeederStartupTask>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotDesk.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
