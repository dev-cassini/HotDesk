using System;
using HotDesk.Application.Dtos.Desks;
using HotDesk.Domain.Entities;

namespace HotDesk.Application.Mappers
{
    public static class DeskMapper
    {
        public static DeskDto ToDto(this Desk desk)
        {
            if (desk.Department is null)
            {
                throw new Exception($"Error mapping desk {desk.Id} to dto. Department property is not populated.");
            }

            if (desk.Bookings is null)
            {
                throw new Exception($"Error mapping desk {desk.Id} to dto. Bookings property is not populated.");
            }

            return new DeskDto(
                desk.Id,
                desk.Name,
                desk.Department.Name,
                desk.XCoordinate,
                desk.YCoordinate,
                desk.Width,
                desk.Height,
                desk.IsBooked);
        }
    }
}
