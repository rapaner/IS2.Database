using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class VersionTypeConfiguration : IEntityTypeConfiguration<VersionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<VersionTypeEntity> entity)
        {
            entity.ToTable("VersionTypes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name)
                .IsRequired();
        }
    }
}