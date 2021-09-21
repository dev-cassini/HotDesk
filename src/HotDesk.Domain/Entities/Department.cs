using HotDesk.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.Entities
{
    public class Department : DomainEntity
    {
        /// <summary>
        /// Name of department.
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// Is the department enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// A list of locations in which the department exists.
        /// </summary>
        public List<LocationDepartment>? LocationDepartments { get; protected set; }

        protected Department()
        {
        }

        public Department(Guid id, string name, bool enabled) : base(id)
        {
            Name = name;
            Enabled = enabled;
        }
    }
}
