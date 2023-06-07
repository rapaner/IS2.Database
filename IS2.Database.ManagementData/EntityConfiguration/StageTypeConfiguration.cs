using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    internal class StageTypeConfiguration : IEntityTypeConfiguration<StageTypeEntity>
    {
        public void Configure(EntityTypeBuilder<StageTypeEntity> entity)
        {
            entity.ToTable(" StageTypes");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.StageTypeId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.SpecificationTemplatePackageId).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}