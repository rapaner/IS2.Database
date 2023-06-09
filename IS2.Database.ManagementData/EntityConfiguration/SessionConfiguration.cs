﻿using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    internal class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> entity)
        {
            entity.ToTable("Sessions");

            entity.HasKey(e => e.SessionId);
            entity.Property(e => e.AssignmentId).IsRequired();
            entity.Property(e => e.DateStart).IsRequired();
            entity.Property(e => e.DateFinish);
        }
    }
}