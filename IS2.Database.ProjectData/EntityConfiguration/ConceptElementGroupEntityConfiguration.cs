using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ConceptElementGroupEntityConfiguration : IEntityTypeConfiguration<ConceptElementGroupEntity>
    {
        public void Configure(EntityTypeBuilder<ConceptElementGroupEntity> entity)
        {
            entity.ToTable("ConceptElementGroups");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ConceptElementGroupId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}