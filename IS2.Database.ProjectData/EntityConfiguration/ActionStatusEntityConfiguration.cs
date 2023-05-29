using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ActionStatusEntityConfiguration : IEntityTypeConfiguration<ActionStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ActionStatusEntity> entity)
        {
            entity.ToTable("ActionStatuses");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ActionStatusId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}