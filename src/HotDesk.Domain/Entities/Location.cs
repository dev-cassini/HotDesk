using FluentValidation;
using HotDesk.Domain.Entities.Common;
using HotDesk.Domain.Entities.Validators;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.Entities
{
    public class Location : DomainEntity
    {
        /// <summary>
        /// Name of location.
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// Is the location enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// A list of departments which exist in this location.
        /// </summary>
        public List<Department>? Departments { get; protected set; }

        protected Location()
        {
        }

        public Location(Guid id, string name, bool enabled) : base(id)
        {
            Name = name;
            Enabled = enabled;

            new LocationValidator().ValidateAndThrow(this);
        }
    }
}
