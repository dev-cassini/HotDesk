using System;

namespace HotDesk.Domain.Entities.Common
{
    public interface IDomainEntity
    {
        /// <summary>
        /// Id of domain entity.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Date and time, in UTC, when the domain entity was created.
        /// </summary>
        DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Date and time, in UTC, when the domain entity was last updated.
        /// </summary>
        DateTimeOffset LastUpdatedAt { get; }
    }
}
