using System;

namespace HotDesk.Application.Dtos.Desks
{
    public class DeskDto : IDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string LocationName { get; init; } = string.Empty;

        public string DepartmentName { get; init; } = string.Empty;

        public int XCoordinate { get; init; }

        public int YCoordinate { get; init; }

        public int Width { get; init; }

        public int Height { get; init; }
    }
}
