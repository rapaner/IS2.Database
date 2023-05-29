using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    class ProcedureToModuleConfiguration : IEntityTypeConfiguration<ProcedureToModuleEntity>
    {
        public void Configure(EntityTypeBuilder<ProcedureToModuleEntity> entity)
        {
            entity.ToTable("ProcedureToModules");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProcedureId).IsRequired();
            entity.Property(e => e.ModuleId).IsRequired();
            entity.Property(e => e.ProcedureAvailabilityTypeId).IsRequired();
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}