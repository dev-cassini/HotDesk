using HotDesk.Domain.Entities.Common;
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
        /// Id of the location department to which the desk belongs.
        /// </summary>
        public Guid LocationDepartmentId { get; protected set; }

        /// <summary>
        /// Location department to which the desk belongs.
        /// </summary>
        public LocationDepartment LocationDepartment { get; protected set; } = null!;

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
            Guid locationDepartmentId,
            bool enabled) : base(id)
        {
            Name = name;
            LocationDepartmentId = locationDepartmentId;
            Enabled = enabled;
        }
    }
}
