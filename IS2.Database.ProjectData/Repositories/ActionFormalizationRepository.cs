using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы со степенями формализации действий
    /// </summary>
    public class ActionFormalizationRepository : IVersioningRepository<ActionFormalizationEntity, short>
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ActionFormalizationRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionFormalizationEntity Add(ActionFormalizationEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionFormalizations.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionFormalizationEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionFormalizations
                .Where(s => s.ActionFormalizationId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionFormalizationEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ActionFormalizations
                .Where(s => s.ActionFormalizationId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}