using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class SettingConfiguration : IEntityTypeConfiguration<SettingEntity>
    {
        public void Configure(EntityTypeBuilder<SettingEntity> entity)
        {
            entity.ToTable("Settings");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.SettingId)
                .IsRequired();
            entity.HasIndex(e => e.SettingId);

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.VersionId)
                .IsRequired();

            entity.Property(e => e.DateInsert)
                .IsRequired();

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity.Property(e => e.VersionId)
                .IsRequired();

            entity.Property(e => e.DateInsert)
                .IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}