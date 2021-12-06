using FluentValidation;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private readonly IDataSeedingRepository<Floorplan> _floorplanRepository;
        private readonly IDataSeedingRepository<Location> _locationRepository;
        private readonly IDataSeedingRepository<LocationDepartment> _locationDepartmentRepository;
        private readonly IDataSeedingRepository<Person> _personRepository;

        public DataSeeder(
            ILogger<DataSeeder> logger,
            IDataSeedingRepository<Booking> bookingRepository,
            IDataSeedingRepository<Department> departmentRepository,
            IDataSeedingRepository<Desk> deskRepository,
            IDataSeedingRepository<Floorplan> floorplanRepository,
            IDataSeedingRepository<Location> locationRepository,
            IDataSeedingRepository<LocationDepartment> locationDepartmentRepository,
            IDataSeedingRepository<Person> personRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
            _departmentRepository = departmentRepository;
            _deskRepository = deskRepository;
            _floorplanRepository = floorplanRepository;
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

            _logger.LogInformation("Seeding floorplans.");
            var floorplan = new Floorplan(
                new Guid("fbc006d5-0383-400d-aacb-713242366d22"),
                "Seeded Floorplan",
                location.Id,
                true,
                new List<IValidator<Floorplan>>());
            await _floorplanRepository.PutAsync(floorplan);

            var desks = await SeedDesks(floorplan.Id, department.Id);
            
            _logger.LogInformation("Seeding bookings.");
            var booking = new Booking(
                new Guid("3e749af0-70d0-48a0-905b-0cf293b8b74b"),
                desks[0].Id,
                person.Id,
                new DateTimeOffset(DateTime.UtcNow.AddDays(1).Date),
                new DateTimeOffset(DateTime.UtcNow.AddDays(2).Date));
            await _bookingRepository.PutAsync(booking);

            _logger.LogInformation("Data seeding complete.");
        }

        private async Task<List<Desk>> SeedDesks(Guid floorplanId, Guid departmentId)
        {
            _logger.LogInformation("Seeding desks.");
            var desks = new List<Desk>();

            desks.Add(new Desk(
                new Guid("cd9e04a6-181b-44a1-be26-fe7899723276"),
                "Seeded Desk 1",
                floorplanId,
                departmentId,
                50,
                175,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("3943212f-0735-402c-8c12-04621b5511c1"),
                "Seeded Desk 2",
                floorplanId,
                departmentId,
                235,
                175,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("b9214334-f4c1-45fe-953d-360543fab4f3"),
                "Seeded Desk 3",
                floorplanId,
                departmentId,
                420,
                175,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("1aee262c-30f0-4085-ac60-1c7934c48951"),
                "Seeded Desk 4",
                floorplanId,
                departmentId,
                50,
                280,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("e4146372-6597-4ce8-b177-d5753b3d36dc"),
                "Seeded Desk 5",
                floorplanId,
                departmentId,
                235,
                280,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("750ab000-1c03-45ab-a54c-264b56886828"),
                "Seeded Desk 6",
                floorplanId,
                departmentId,
                420,
                280,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("3de67874-741b-40c5-ad42-fa3eb6fe07f3"),
                "Seeded Desk 7",
                floorplanId,
                departmentId,
                50,
                490,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("d7bc690f-6b9d-46b6-a6f9-0029f9a0974d"),
                "Seeded Desk 8",
                floorplanId,
                departmentId,
                235,
                490,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("d8f21f7d-68db-4a99-992c-ffb9329822c1"),
                "Seeded Desk 9",
                floorplanId,
                departmentId,
                420,
                490,
                180,
                100,
                true));

            desks.Add(new Desk(
                new Guid("1a315721-8290-4abc-a980-633a2b615c25"),
                "Seeded Desk 10",
                floorplanId,
                departmentId,
                710,
                175,
                100,
                180,
                true));

            desks.Add(new Desk(
                new Guid("3b3e5098-147e-4e1c-8c88-479cc37bb7fd"),
                "Seeded Desk 11",
                floorplanId,
                departmentId,
                710,
                410,
                100,
                180,
                true));

            foreach (var desk in desks)
            {
                await _deskRepository.PutAsync(desk);
            }

            return desks;
        }
    }
}
