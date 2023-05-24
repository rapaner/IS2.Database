using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ConfigurationData.EntityConfiguration
{
    class VersionTypeConfiguration : IEntityTypeConfiguration<VersionType>
    {
        public void Configure(EntityTypeBuilder<VersionType> entity)
        {
            entity.ToTable("VersionTypes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name)
                .IsRequired();
        }
    }
}