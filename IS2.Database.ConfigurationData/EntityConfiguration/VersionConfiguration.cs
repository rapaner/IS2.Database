using IS2.Database.Common.Model;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class VersionConfiguration : IEntityTypeConfiguration<Model.Version>
    {
        public void Configure(EntityTypeBuilder<Model.Version> entity)
        {
            entity.ToTable("Versions");

            entity.HasKey(e => e.VersionId);
            entity.Property(e => e.VersionType)
                .HasConversion(
                    v => v.Id,
                    v => Enumeration.FromValue<VersionType>(v)
                );
            entity.Property(e => e.PreviousVersionId);
            entity.Property(e => e.UserId)
                .IsRequired();
            entity.Property(e => e.VersionDate)
                .IsRequired();
            entity.Property(e => e.Name)
                .IsRequired();
            entity.Property(e => e.Comment);
        }
    }
}