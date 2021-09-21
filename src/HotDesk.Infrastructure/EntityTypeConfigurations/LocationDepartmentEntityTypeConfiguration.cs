using HotDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class LocationDepartmentEntityTypeConfiguration : IEntityTypeConfiguration<LocationDepartment>
    {
        public void Configure(EntityTypeBuilder<LocationDepartment> builder)
        {
            builder.HasKey(locationDepartment => locationDepartment.Id);
            builder.HasIndex(locationDepartment => new { locationDepartment.LocationId, locationDepartment.DepartmentId }).IsUnique();

            builder
                .HasOne(locationDepartment => locationDepartment.Location)
                .WithMany(location => location.LocationDepartments);

            builder
                .HasOne(locationDepartment => locationDepartment.Department)
                .WithMany(department => department.LocationDepartments);
        }
    }
}
