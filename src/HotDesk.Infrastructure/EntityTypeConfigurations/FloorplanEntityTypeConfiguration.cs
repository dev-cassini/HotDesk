using HotDesk.Domain.Entities;
using HotDesk.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class FloorplanEntityTypeConfiguration : IEntityTypeConfiguration<Floorplan>
    {
        public void Configure(EntityTypeBuilder<Floorplan> builder)
        {
            builder.HasKey(floorplan => floorplan.Id);
            builder.HasIndex(floorplan => floorplan.Name).IsUnique();
            builder.Property(floorplan => floorplan.Name).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
            builder.HasOne(floorplan => floorplan.Location);

            builder
                .HasMany(floorplan => floorplan.Desks)
                .WithOne(desk => desk.Floorplan)
                .HasForeignKey(desk => desk.FloorplanId);
        }
    }
}
