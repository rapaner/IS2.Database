using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    internal class ProcedureConfiguration : IEntityTypeConfiguration<ProcedureEntity>
    {
        public void Configure(EntityTypeBuilder<ProcedureEntity> entity)
        {
            entity.ToTable("Procedures");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ProcedureId)
                .IsRequired()
                .ValueGeneratedOnAdd();
            entity.Property(e => e.ProcedureTypeId).IsRequired();
            entity.Property(e => e.StageId).IsRequired();
            entity.Property(e => e.StatusId).IsRequired();
            entity.Property(e => e.DateStartPlan).IsRequired();
            entity.Property(e => e.DateFinishPlan).IsRequired();
            entity.Property(e => e.DateStartFact);
            entity.Property(e => e.DateFinishFact);
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}