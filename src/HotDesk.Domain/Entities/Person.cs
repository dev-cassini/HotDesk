using HotDesk.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace HotDesk.Domain.Entities
{
    public class Person : DomainEntity
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; protected set; } = string.Empty;

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; protected set; } = string.Empty;

        /// <summary>
        /// Is person enabled?
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        /// A list of bookings associated with this person.
        /// </summary>
        public List<Booking>? Bookings { get; protected set; }

        protected Person()
        {
        }

        public Person(Guid id, string firstName, string lastName, bool enabled) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Enabled = enabled;
        }
    }
}
