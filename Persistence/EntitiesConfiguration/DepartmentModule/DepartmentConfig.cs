using Domain.DepartmentModule;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesConfiguration.DepartmentModule;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasOne(d => d.Manager)
            .WithOne(u => u.Department)
            .HasForeignKey<Department>(d => d.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}