using FluentValidation;
using HotDesk.Domain.Entities.Common;
using HotDesk.Domain.Entities.Validators;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.Entities
{
    public class Desk : DomainEntity
    {
        /// <summary>
        /// Name of desk.
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// Id of location.
        /// </summary>
        public Guid LocationId { get; protected set; }

        /// <summary>
        /// Location of desk.
        /// </summary>
        public Location Location { get; protected set; }

        /// <summary>
        /// Id of the department to which the desk belongs.
        /// </summary>
        public Guid DepartmentId { get; protected set; }

        /// <summary>
        /// Department to which the desk belongs.
        /// </summary>
        public Department Department { get; protected set; }

        /// <summary>
        /// Is the desk enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// A list of bookings associated with this desk.
        /// </summary>
        public List<Booking>? Bookings { get; protected set; }

        protected Desk()
        {
        }

        public Desk(
            Guid id,
            string name,
            Location location,
            Department department,
            bool enabled) : base(id)
        {
            Name = name;
            Location = location;
            Department = department;
            Enabled = enabled;

            new DeskValidator().ValidateAndThrow(this);
        }
    }
}
