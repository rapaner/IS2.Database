using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ConceptElementEntityConfiguration : IEntityTypeConfiguration<ConceptElementEntity>
    {
        public void Configure(EntityTypeBuilder<ConceptElementEntity> entity)
        {
            entity.ToTable("ConceptElements");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ConceptElementId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.ModelId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ConceptElementClassId).IsRequired();
            entity.Property(e => e.ConceptElementGroupId).IsRequired();
            entity.Property(e => e.Number).IsRequired();
            entity.Property(e => e.IsAutoRange).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}