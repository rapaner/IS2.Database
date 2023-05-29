using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> entity)
        {
            entity.ToTable("Users");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.MiddleName).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}