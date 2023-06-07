using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ProjectData.EntityConfiguration
{
    internal class ActionLinkEntityConfiguration : IEntityTypeConfiguration<ActionLinkEntity>
    {
        public void Configure(EntityTypeBuilder<ActionLinkEntity> entity)
        {
            entity.ToTable("ActionLinks");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ActionLinkId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.ModelId).IsRequired();
            entity.Property(e => e.LinkTypeId).IsRequired();
            entity.Property(e => e.ActionId1).IsRequired();
            entity.Property(e => e.ActionId2).IsRequired();
            entity.Property(e => e.ActionId3);
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}