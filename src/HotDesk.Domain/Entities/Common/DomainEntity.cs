﻿using System;

namespace HotDesk.Domain.Entities.Common
{
    public class DomainEntity : IDomainEntity
    {
        public Guid Id { get; }
        public DateTimeOffset CreatedAt { get; protected set; }
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
