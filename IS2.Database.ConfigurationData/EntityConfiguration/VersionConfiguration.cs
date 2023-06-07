using IS2.Database.Common.Model;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    internal class VersionConfiguration : IEntityTypeConfiguration<VersionEntity>
    {
        public void Configure(EntityTypeBuilder<VersionEntity> entity)
        {
            entity.ToTable("Versions");

            entity.HasKey(e => e.VersionId);
            entity.Property(e => e.VersionType)
                .HasConversion(
                    v => v.Id,
                    v => Enumeration.FromValue<VersionTypeEntity>(v)
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