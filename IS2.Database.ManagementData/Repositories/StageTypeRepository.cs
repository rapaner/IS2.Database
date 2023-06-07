using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с типами этапов
    /// </summary>
    public class StageTypeRepository : IVersioningRepository<StageTypeEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public StageTypeRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public StageTypeEntity Add(StageTypeEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.StageTypes.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StageTypeEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.StageTypes
                .Where(s => s.StageTypeId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<StageTypeEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.StageTypes
                .Where(s => s.StageTypeId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}