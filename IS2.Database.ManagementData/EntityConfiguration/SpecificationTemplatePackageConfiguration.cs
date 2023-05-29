using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    class SpecificationTemplatePackageConfiguration : IEntityTypeConfiguration<SpecificationTemplatePackageEntity>
    {
        public void Configure(EntityTypeBuilder<SpecificationTemplatePackageEntity> entity)
        {
            entity.ToTable("SpecificationTemplatePackages");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.SpecificationTemplatePackageId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.TableName).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}