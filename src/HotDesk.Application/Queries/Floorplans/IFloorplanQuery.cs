using HotDesk.Application.Dtos.Floorplans;
using System;
using System.Threading.Tasks;

namespace HotDesk.Application.Queries.Floorplans
{
    public interface IFloorplanQuery
    {
        Task<FloorplanDto?> GetAsync(Guid floorplanId);
    }
}
