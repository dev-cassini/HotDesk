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

        public string Name { get; } = string.Empty;

        public string LocationName { get; } = string.Empty;

        public List<DeskDto> Desks { get; } = new();
    }
}
