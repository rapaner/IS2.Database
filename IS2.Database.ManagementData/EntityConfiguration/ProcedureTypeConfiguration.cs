using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    class ProcedureTypeConfiguration : IEntityTypeConfiguration<ProcedureTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ProcedureTypeEntity> entity)
        {
            entity.ToTable("ProcedureTypes");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProcedureTypeId).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}