using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ModelEntityConfiguration : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> entity)
        {
            entity.ToTable("Models");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ModelId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ProjectId).IsRequired();
            entity.Property(e => e.ModelTypeId).IsRequired();
            entity.Property(e => e.ModelStatusId).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}