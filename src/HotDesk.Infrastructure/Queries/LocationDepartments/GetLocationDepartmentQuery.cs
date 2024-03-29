﻿using HotDesk.Application.Queries.LocationDepartments;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Queries.LocationDepartments
{
    public class GetLocationDepartmentQuery : ILocationDepartmentQuery
    {
        private readonly IReadOnlyRepository _dbContext;

        public GetLocationDepartmentQuery(IReadOnlyRepository dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<LocationDepartmentDto?> GetAsync(Guid locationId, Guid departmentId)
        //{
        //    var locationDepartment = await _dbContext.Query<LocationDepartment>()
        //        .SingleOrDefaultAsync(ld => ld.LocationId == locationId && ld.DepartmentId == departmentId);

        //    if (locationDepartment is null)
        //    {
        //        return null;
        //    }

        //    return new LocationDepartmentDto
        //    {
        //        Id = locationDepartment.Id,
        //        Locationid = locationDepartment.LocationId,
        //        DepartmentId = locationDepartment.DepartmentId
        //    };
        //}
    }
}
