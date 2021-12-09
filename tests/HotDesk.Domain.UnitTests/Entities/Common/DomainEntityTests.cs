using FluentAssertions;
using FluentValidation;
using HotDesk.Domain.Entities.Common;
using NUnit.Framework;
using System;

namespace HotDesk.Domain.UnitTests.Entities.Common
{
    [TestFixture]
    public class DomainEntityTests
    {
        [Test]
        public void ValidationExceptionIsThrownWhenIdIsEmptyGuid()
        {
            var exception = Assert.Throws<ValidationException>(() =>
            {
                new DomainEntity(Guid.Empty);
            });

            exception!.Message.Should().Contain("Validation failed");
        }

        [Test]
        public void PropertiesAreSetAsExpected()
        {
            var id = Guid.NewGuid();
            var domainEntity = new DomainEntity(id);

            domainEntity.Id.Should().Be(id);
            domainEntity.CreatedAt.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(1));
            domainEntity.LastUpdatedAt.Should().Be(domainEntity.CreatedAt);
        }
    }
}
