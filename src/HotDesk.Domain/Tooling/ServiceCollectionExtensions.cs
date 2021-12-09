using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Validators.Bookings;
using HotDesk.Domain.Validators.Departments;
using HotDesk.Domain.Validators.Desks;
using HotDesk.Domain.Validators.Floorplans;
using HotDesk.Domain.Validators.LocationDepartments;
using HotDesk.Domain.Validators.Locations;
using HotDesk.Domain.Validators.Persons;
using Microsoft.Extensions.DependencyInjection;

namespace HotDesk.Domain.Tooling
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHotDeskDomainServices(this IServiceCollection services)
        {
            services.AddTransient<DataSeeder>();

            AddDomainValidators(services);
            AddForeignKeyValidators(services);
        }

        private static void AddDomainValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Booking>, BookingValidator>();
            services.AddScoped<IValidator<Department>, DepartmentValidator>();
            services.AddScoped<IValidator<Desk>, DeskValidator>();
            services.AddScoped<IValidator<Floorplan>, FloorplanValidator>();
            services.AddScoped<IValidator<LocationDepartment>, LocationDepartmentValidator>();
            services.AddScoped<IValidator<Location>, LocationValidator>();
            services.AddScoped<IValidator<Person>, PersonValidator>();
        }

        private static void AddForeignKeyValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Booking>, BookingForeignKeyValidator>();
            services.AddScoped<IValidator<Desk>, DeskForeignKeyValidator>();
            services.AddScoped<IValidator<Floorplan>, FloorplanForeignKeyValidator>();
            services.AddScoped<IValidator<LocationDepartment>, LocationDepartmentForeignKeyValidator>();
        }
    }
}
