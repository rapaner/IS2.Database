using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> entity)
        {
            entity.ToTable("UserSettings");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserSettingId)
                .IsRequired();
            entity.HasIndex(e => e.UserSettingId);
            entity.Property(e => e.SettingId)
                .IsRequired();
            entity.Property(e => e.UserId)
                .IsRequired();
            entity.Property(e => e.Value)
                .IsRequired();
            entity.Property(e => e.VersionId)
                .IsRequired();
            entity.Property(e => e.DateInsert)
                .IsRequired();
            entity.Property(e => e.IsDeleted)
                .IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}