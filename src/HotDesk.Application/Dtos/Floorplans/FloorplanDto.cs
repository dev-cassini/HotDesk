using HotDesk.Application.Dtos.Desks;
using System;
using System.Collections.Generic;

namespace HotDesk.Application.Dtos.Floorplans
{
    public class FloorplanDto
    {
        public FloorplanDto(
            Guid id,
            string name,
            string locationName,
            List<DeskDto> desks)
        {
            Id = id;
            Name = name;
            LocationName = locationName;
            Desks = desks;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string LocationName { get; }

        public List<DeskDto> Desks { get; }
    }
}
