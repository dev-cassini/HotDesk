using System;

namespace HotDesk.Application.Dtos.Desks
{
    public class DeskDto : IDto
    {
        public DeskDto(
            Guid id,
            string name,
            string departmentName,
            int xCoordinate,
            int yCoordinate,
            int width,
            int height)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Width = width;
            Height = height;
        }

        public Guid Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public string DepartmentName { get; init; } = string.Empty;

        public int XCoordinate { get; init; }

        public int YCoordinate { get; init; }

        public int Width { get; init; }

        public int Height { get; init; }
    }
}
