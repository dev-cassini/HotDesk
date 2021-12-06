using HotDesk.Application.Dtos.Floorplans;
using HotDesk.Application.Mappers;
using HotDesk.Application.Queries.Floorplans;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotDesk.Infrastructure.Queries.Floorplans
{
    public class EfFloorplanQuery : IFloorplanQuery
    {
        private readonly IReadOnlyRepository _readOnlyRepository;

        public EfFloorplanQuery(IReadOnlyRepository readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<FloorplanDto?> GetAsync(Guid floorplanId)
        {
            var floorplan = await _readOnlyRepository.Query<Floorplan>()
                .Include(floorplan => floorplan.Location)
                .Include(floorplan => floorplan.Desks)
                .ThenInclude(desk => desk.Department)
                .SingleOrDefaultAsync(floorplan => floorplan.Id == floorplanId);

            if (floorplan is null)
            {
                return null;
            }

            return new FloorplanDto(
                floorplan.Id,
                floorplan.Name,
                floorplan.Location.Name,
                floorplan.Desks!.Select(desk => desk.ToDto()).ToList());
        }
    }
}
