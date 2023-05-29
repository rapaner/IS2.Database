using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class BranchConfiguration : IEntityTypeConfiguration<BranchEntity>
    {
        public void Configure(EntityTypeBuilder<BranchEntity> entity)
        {
            entity.ToTable("Branches");
            entity.HasKey(e => e.BranchId);
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.IsDeleted)
                .IsRequired();

            entity
                .HasMany(e => e.Versions)
                .WithOne(v => v.Branch)
                .HasForeignKey(e => e.BranchId)
                .IsRequired();
        }
    }
}