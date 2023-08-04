using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntitiesConfiguration.UserModule;

public class ManagerConfig : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.HasMany(m => m.Tasks)
            .WithOne(t => t.AssignedBy)
            .HasForeignKey(m => m.AssignedById);
    }
}