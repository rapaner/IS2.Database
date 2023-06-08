using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы со статусами моделей
    /// </summary>
    public class ModelStatusRepository : IVersioningRepository<ModelStatusEntity, Guid>
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ModelStatusRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ModelStatusEntity Add(ModelStatusEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ModelStatuses.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ModelStatusEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ModelStatuses
                .Where(s => s.ModelStatusId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ModelStatusEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ModelStatuses
                .Where(s => s.ModelStatusId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}