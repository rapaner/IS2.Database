using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы со статусами действий
    /// </summary>
    public class ActionStatusRepository : IVersioningRepository<ActionStatusEntity, short>
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ActionStatusRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionStatusEntity Add(ActionStatusEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionStatuses.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionStatusEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionStatuses
                .Where(s => s.ActionStatusId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionStatusEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ActionStatuses
                .Where(s => s.ActionStatusId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}