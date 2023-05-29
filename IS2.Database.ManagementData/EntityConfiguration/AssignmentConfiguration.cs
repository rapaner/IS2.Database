using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS2.Database.ManagementData.EntityConfiguration
{
    class AssignmentConfiguration : IEntityTypeConfiguration<AssignmentEntity>
    {
        public void Configure(EntityTypeBuilder<AssignmentEntity> entity)
        {
            entity.ToTable("Assignments");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.AssignmentId).IsRequired();
            entity.Property(e => e.ProcedureId).IsRequired();
            entity.Property(e => e.RoleId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.DateStart).IsRequired();
            entity.Property(e => e.DateFinish);
            entity.Property(e => e.VersionId).IsRequired();
            entity.Property(e => e.DateInsert).IsRequired();
            entity.Property(e => e.IsDeleted).IsRequired();

            entity.HasIndex(e => new { e.VersionId, e.DateInsert, e.IsDeleted });
        }
    }
}