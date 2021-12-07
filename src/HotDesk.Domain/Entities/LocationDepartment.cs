using FluentValidation;
using HotDesk.Domain.Entities.Common;
using System;
using System.Collections.Generic;

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
        public Location Location { get; protected set; }

        /// <summary>
        /// Id of department.
        /// </summary>
        public Guid DepartmentId { get; protected set; }

        /// <summary>
        /// Department.
        /// </summary>
        public Department Department { get; protected set; }

        /// <summary>
        /// Persons that belong to the location department.
        /// </summary>
        public List<Person>? Persons { get; protected set; }

        /// <summary>
        /// Is the location department enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        protected LocationDepartment()
        {
        }

        public LocationDepartment(
            Guid id,
            Guid locationId,
            Guid departmentId,
            bool enabled,
            List<IValidator<LocationDepartment>> validators) : base(id)
        {
            LocationId = locationId;
            DepartmentId = departmentId;
            Enabled = enabled;

            foreach (var validator in validators)
            {
                validator.ValidateAndThrow(this);
            }
        }
    }
}
