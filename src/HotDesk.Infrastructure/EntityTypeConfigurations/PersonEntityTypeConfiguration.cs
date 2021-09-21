using HotDesk.Domain.Entities;
using HotDesk.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(person => person.Id);
            builder.Property(person => person.FirstName).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
            builder.Property(person => person.LastName).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
            builder.HasIndex(person => new { person.FirstName, person.LastName }).IsUnique();

            builder
                .HasMany(person => person.Bookings)
                .WithOne(booking => booking.Person)
                .HasForeignKey(booking => booking.PersonId);
        }
    }
}
