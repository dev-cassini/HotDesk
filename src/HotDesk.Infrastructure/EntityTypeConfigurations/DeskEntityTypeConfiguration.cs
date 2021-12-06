using HotDesk.Domain.Entities;
using HotDesk.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class DeskEntityTypeConfiguration : IEntityTypeConfiguration<Desk>
    {
        public void Configure(EntityTypeBuilder<Desk> builder)
        {
            builder.HasKey(desk => desk.Id);
            builder.HasIndex(desk => desk.Name).IsUnique();
            builder.Property(desk => desk.Name).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
            builder.HasOne(desk => desk.Department);

            builder
                .HasMany(desk => desk.Bookings)
                .WithOne(booking => booking.Desk)
                .HasForeignKey(booking => booking.DeskId);
        }
    }
}
