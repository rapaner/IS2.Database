using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с этапами
    /// </summary>
    public class StageRepository : IVersioningRepository<StageEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public StageRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public StageEntity Add(StageEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Stages.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StageEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Stages
                .Where(s => s.StageId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<StageEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Stages
                .Where(s => s.StageId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}