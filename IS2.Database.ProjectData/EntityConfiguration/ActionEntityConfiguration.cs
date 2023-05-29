using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ActionEntityConfiguration : IEntityTypeConfiguration<ActionEntity>
    {
        public void Configure(EntityTypeBuilder<ActionEntity> entity)
        {
            entity.ToTable("Actions");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ActionId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ProjectId).IsRequired();
            entity.Property(e => e.ModelId).IsRequired();
            entity.Property(e => e.LocalNumber).IsRequired();
            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.Number).IsRequired();
            entity.Property(e => e.ActionStatusId).IsRequired();
            entity.Property(e => e.ActionFormalizationId).IsRequired();
            entity.Property(e => e.ActionTypeId).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}