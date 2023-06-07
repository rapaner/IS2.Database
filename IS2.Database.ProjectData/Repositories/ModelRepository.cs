using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с моделями
    /// </summary>
    public class ModelRepository : IVersioningRepository<ModelEntity, Guid>
    {
        private readonly ProjectDataContext _context;

        public ModelRepository(ProjectDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ModelEntity Add(ModelEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Models.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ModelEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Models
                .Where(s => s.ModelId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ModelEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Models
                .Where(s => s.ModelId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}