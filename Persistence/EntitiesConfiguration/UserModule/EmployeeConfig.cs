using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesConfiguration.UserModule;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasMany(m => m.Tasks)
            .WithOne(t => t.AssignedTo)
            .HasForeignKey(m => m.AssignedToId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

