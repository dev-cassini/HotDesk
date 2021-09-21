using HotDesk.Application.Commands.Bookings;
using HotDesk.Application.Queries.LocationDepartments;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using HotDesk.Infrastructure.Commands.Bookings;
using HotDesk.Infrastructure.Queries.LocationDepartments;
using HotDesk.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotDesk.Infrastructure.Tooling
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHotDeskInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<MigrateDatabase>();
            services.AddTransient(typeof(ReadOnlyDbContext<>)); ///TODO: remove one of these readonly dbcontexts
            services.AddTransient<IReadOnlyRepository, ReadOnlyDbContext<HotDeskDbContext>>();

            AddRepositories(services);
            AddDataSeedingRepositories(services);
            AddQueries(services);
            AddCommands(services);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingRepository, EfBookingRepository>();
            services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
            services.AddScoped<IDeskRepository, EfDeskRepository>();
            services.AddScoped<ILocationRepository, EfLocationRepository>();
            services.AddScoped<ILocationDepartmentRepository, EfLocationDepartmentRepository>();
            services.AddScoped<IPersonRepository, EfPersonRepository>();
        }

        private static void AddDataSeedingRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataSeedingRepository<Booking>, EfBookingRepository>();
            services.AddScoped<IDataSeedingRepository<Department>, EfDepartmentRepository>();
            services.AddScoped<IDataSeedingRepository<Desk>, EfDeskRepository>();
            services.AddScoped<IDataSeedingRepository<Location>, EfLocationRepository>();
            services.AddScoped<IDataSeedingRepository<LocationDepartment>, EfLocationDepartmentRepository>();
            services.AddScoped<IDataSeedingRepository<Person>, EfPersonRepository>();
        }

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IGetLocationDepartmentQuery, GetLocationDepartmentQuery>();
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICreateBookingCommand, CreateBookingCommand>();
        }
    }
}
