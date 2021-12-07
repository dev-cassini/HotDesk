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
            int height,
            bool isBooked)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Width = width;
            Height = height;
            IsBooked = isBooked;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string DepartmentName { get; }

        public int XCoordinate { get; }

        public int YCoordinate { get; }

        public int Width { get; }

        public int Height { get; }

        public bool IsBooked { get; }
    }
}
