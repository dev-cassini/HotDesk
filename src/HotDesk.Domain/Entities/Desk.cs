using FluentValidation;
using HotDesk.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotDesk.Domain.Entities
{
    public class Desk : DomainEntity
    {
        /// <summary>
        /// Name of desk.
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// Id of the floorplan to which the desk belongs.
        /// </summary>
        public Guid FloorplanId { get; protected set; }

        /// <summary>
        /// Floorplan to which the desk belongs.
        /// </summary>
        public Floorplan Floorplan { get; protected set; }

        /// <summary>
        /// Id of the department to which the desk belongs.
        /// </summary>
        public Guid DepartmentId { get; protected set; }

        /// <summary>
        /// Department to which the desk belongs.
        /// </summary>
        public Department Department { get; protected set; }

        /// <summary>
        /// The x-coordinate of the desk.
        /// </summary>
        /// <remarks>Used to construct a floorplan.</remarks>
        public int XCoordinate { get; protected set; }

        /// <summary>
        /// The y-coordinate of the desk.
        /// </summary>
        /// <remarks>Used to construct a floorplan.</remarks>
        public int YCoordinate { get; protected set; }

        /// <summary>
        /// The width of the desk.
        /// </summary>
        /// <remarks>Used to construct a floorplan.</remarks>
        public int Width { get; protected set; }

        /// <summary>
        /// The height of the desk.
        /// </summary>
        /// <remarks>Used to construct a floorplan.</remarks>
        public int Height { get; protected set; }

        /// <summary>
        /// Is the desk enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// A list of bookings associated with this desk.
        /// </summary>
        public List<Booking>? Bookings { get; protected set; }

        public bool IsBooked
        {
            get
            {
                if (Bookings is null)
                {
                    throw new InvalidOperationException($"Cannot ascertain if desk {Id} is booked because bookings is not populated.");
                }

                var dateTimeUtcNow = DateTime.UtcNow;
                return Bookings!.Any(booking => booking.StartTime <= dateTimeUtcNow && booking.EndTime > dateTimeUtcNow);
            }
        }

        protected Desk()
        {
        }

        public Desk(
            Guid id,
            string name,
            Guid floorplanId,
            Guid departmentId,
            int xCoordinate,
            int yCoordinate,
            int width,
            int height,
            bool enabled,
            List<IValidator<Desk>> validators) : base(id)
        {
            Name = name;
            FloorplanId = floorplanId;
            DepartmentId = departmentId;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Width = width;
            Height = height;
            Enabled = enabled;

            foreach (var validator in validators)
            {
                validator.ValidateAndThrow(this);
            }
        }
    }
}
