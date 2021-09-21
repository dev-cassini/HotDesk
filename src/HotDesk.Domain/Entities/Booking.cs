using HotDesk.Domain.Entities.Common;
using System;

namespace HotDesk.Domain.Entities
{
    public class Booking : DomainEntity
    {
        /// <summary>
        /// Id of the desk that the booking is for.
        /// </summary>
        public Guid DeskId { get; protected set; }

        /// <summary>
        /// Desk that the booking is for.
        /// </summary>
        public Desk Desk { get; protected set; } = null!;

        /// <summary>
        /// Id of the person that the desk is booked for.
        /// </summary>
        public Guid PersonId { get; protected set; }

        /// <summary>
        /// Person that the desk is booked for.
        /// </summary>
        public Person Person { get; protected set; } = null!;

        /// <summary>
        /// Start date and time, in UTC, of the booking.
        /// </summary>
        public DateTimeOffset StartTime { get; protected set; }

        /// <summary>
        /// End date and time, in UTC, of the booking.
        /// </summary>
        public DateTimeOffset EndTime { get; protected set; }

        protected Booking()
        {
        }

        public Booking(
            Guid id,
            Guid deskId,
            Guid personId,
            DateTimeOffset startTime,
            DateTimeOffset endTime) : base(id)
        {
            DeskId = deskId;
            PersonId = personId;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
