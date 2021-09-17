using HotDesk.Domain.Entities;
using HotDesk.Domain.Entities.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotDesk.Infrastructure.EntityTypeConfigurations
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.Id);
            builder.HasIndex(desk => desk.Name).IsUnique();
            builder.Property(department => department.Name).IsRequired().HasMaxLength(ValidatorConstants.NameMaxLength);
        }
    }
}
