using HotDesk.Domain.Entities.Common;
using System;

namespace HotDesk.Domain.Entities
{
    public class LocationDepartment : DomainEntity
    {
        /// <summary>
        /// Id of location.
        /// </summary>
        public Guid LocationId { get; protected set; }

        /// <summary>
        /// Location.
        /// </summary>
        public Location Location { get; protected set; } = null!;

        /// <summary>
        /// Id of department.
        /// </summary>
        public Guid DepartmentId { get; protected set; }

        /// <summary>
        /// Department.
        /// </summary>
        public Department Department { get; protected set; } = null!;

        /// <summary>
        /// Is the location department enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        protected LocationDepartment()
        {
        }

        public LocationDepartment(Guid id, Guid locationId, Guid departmentId, bool enabled) : base(id)
        {
            LocationId = locationId;
            DepartmentId = departmentId;
            Enabled = enabled;
        }
    }
}
