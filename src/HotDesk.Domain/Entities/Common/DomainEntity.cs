using System;

namespace HotDesk.Domain.Entities.Common
{
    public class DomainEntity
    {
        /// <summary>
        /// Id of domain entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Date and time, in UTC, when the domain entity was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; protected set; }

        /// <summary>
        /// Date and time, in UTC, when the domain entity was last updated.
        /// </summary>
        public DateTimeOffset LastUpdatedAt { get; protected set; }

        protected DomainEntity()
        {
        }

        public DomainEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = CreatedAt;
        }
    }
}
