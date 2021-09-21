using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotDesk.Domain.Tooling
{
    public class DataSeeder
    {
        private readonly ILogger<DataSeeder> _logger;
        private readonly IDataSeedingRepository<Booking> _bookingRepository;
        private readonly IDataSeedingRepository<Department> _departmentRepository;
        private readonly IDataSeedingRepository<Desk> _deskRepository;
        private readonly IDataSeedingRepository<Location> _locationRepository;
        private readonly IDataSeedingRepository<LocationDepartment> _locationDepartmentRepository;
        private readonly IDataSeedingRepository<Person> _personRepository;

        public DataSeeder(
            ILogger<DataSeeder> logger,
            IDataSeedingRepository<Booking> bookingRepository,
            IDataSeedingRepository<Department> departmentRepository,
            IDataSeedingRepository<Desk> deskRepository,
            IDataSeedingRepository<Location> locationRepository,
            IDataSeedingRepository<LocationDepartment> locationDepartmentRepository,
            IDataSeedingRepository<Person> personRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
            _departmentRepository = departmentRepository;
            _deskRepository = deskRepository;
            _locationRepository = locationRepository;
            _locationDepartmentRepository = locationDepartmentRepository;
            _personRepository = personRepository;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting data seeding process...");

            _logger.LogInformation("Seeding persons.");
            var person = new Person(
                new Guid("58129a41-0fc8-4125-8fee-b2a79708f50f"),
                "Seeded",
                "Person",
                true);
            await _personRepository.PutAsync(person);

            _logger.LogInformation("Seeding locations.");
            var location = new Location(
                new Guid("d7c836c6-2643-4ea1-aa12-755c3b630251"),
                "Seeded Location",
                true);
            await _locationRepository.PutAsync(location);

            _logger.LogInformation("Seeding departments.");
            var department = new Department(
                new Guid("99243db7-9651-42d2-b2ca-e66939284721"),
                "Seeded Department",
                true);
            await _departmentRepository.PutAsync(department);

            _logger.LogInformation("Seeding location departments.");
            var locationDepartment = new LocationDepartment(
                new Guid("223d3198-e6d4-477c-a007-7de15d736c7b"),
                location.Id,
                department.Id,
                true);
            await _locationDepartmentRepository.PutAsync(locationDepartment);

            _logger.LogInformation("Seeding desks.");
            var desk = new Desk(
                new Guid("cd9e04a6-181b-44a1-be26-fe7899723276"),
                "Seeded Desk",
                locationDepartment.Id,
                true);
            await _deskRepository.PutAsync(desk);

            _logger.LogInformation("Seeding bookings.");
            var booking = new Booking(
                new Guid("3e749af0-70d0-48a0-905b-0cf293b8b74b"),
                desk.Id,
                person.Id,
                new DateTimeOffset(DateTime.UtcNow.AddDays(1).Date),
                new DateTimeOffset(DateTime.UtcNow.AddDays(2).Date));
            await _bookingRepository.PutAsync(booking);

            _logger.LogInformation("Data seeding complete.");
        }
    }
}
