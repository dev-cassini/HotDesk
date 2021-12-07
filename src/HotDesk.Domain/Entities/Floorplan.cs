using FluentValidation;
using HotDesk.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.Entities
{
    public class Floorplan : DomainEntity
    {
        /// <summary>
        /// Name of floorplan.
        /// </summary>
        public string Name { get; protected set; } = string.Empty;

        /// <summary>
        /// Id of the location to which the floorplan belongs.
        /// </summary>
        public Guid LocationId { get; protected set; }

        /// <summary>
        /// Location to which the floorplan belongs.
        /// </summary>
        public Location Location { get; protected set; }

        /// <summary>
        /// Desks contained within the floorplan.
        /// </summary>
        public List<Desk>? Desks { get; protected set; }

        /// <summary>
        /// Is the floorplan enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        protected Floorplan()
        {
        }

        public Floorplan(
            Guid id,
            string name,
            Guid locationId,
            bool enabled,
            List<IValidator<Floorplan>> validators) : base(id)
        {
            Name = name;
            LocationId = locationId;
            Enabled = enabled;

            foreach (var validator in validators)
            {
                validator.ValidateAndThrow(this);
            }
        }
    }
}
