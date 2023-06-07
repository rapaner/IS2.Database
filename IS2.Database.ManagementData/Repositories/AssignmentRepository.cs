using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий назначений
    /// </summary>
    public class AssignmentRepository : IVersioningRepository<AssignmentEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public AssignmentRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public AssignmentEntity Add(AssignmentEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Assignments.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AssignmentEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Assignments
                .Where(s => s.AssignmentId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<AssignmentEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Assignments
                .Where(s => s.AssignmentId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}