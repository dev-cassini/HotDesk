using HotDesk.Domain.Entities;
using HotDesk.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(location => location.Id);
            builder.HasIndex(location => location.Name).IsUnique();
            builder.Property(location => location.Name).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
        }
    }
}
