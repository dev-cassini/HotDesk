using HotDesk.Application.Dtos.Desks;
using HotDesk.Application.Queries.Desks;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Queries.Desks
{
    public class DeskQuery : IDeskQuery
    {
        private readonly IReadOnlyRepository _readOnlyRepository;

        public DeskQuery(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<List<DeskDto>> GetAsync(Guid locationId, Guid departmentId)
        {
            var desks = await _readOnlyRepository.Query<Desk>()
                .Include(desk => desk.LocationDepartment)
                .ThenInclude(locationDepartment => locationDepartment.Location)
                .Include(desk => desk.LocationDepartment)
                .ThenInclude(locationDepartment => locationDepartment.Department)
                .Where(desk
                    => desk.LocationDepartment.LocationId == locationId &&
                       desk.LocationDepartment.DepartmentId == departmentId)
                .ToListAsync();

            return desks.Select(desk => new DeskDto
            {
                Id = desk.Id,
                Name = desk.Name,
                LocationName = desk.LocationDepartment.Location.Name,
                DepartmentName = desk.LocationDepartment.Department.Name,
                XCoordinate = desk.XCoordinate,
                YCoordinate = desk.YCoordinate,
                Width = desk.Width,
                Height = desk.Height
            }).ToList();
        }
    }
}
