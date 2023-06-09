﻿using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    internal class UserSettingConfiguration : IEntityTypeConfiguration<UserSettingEntity>
    {
        public void Configure(EntityTypeBuilder<UserSettingEntity> entity)
        {
            entity.ToTable("UserSettings");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserSettingId)
                .IsRequired()
                .ValueGeneratedOnAdd();
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