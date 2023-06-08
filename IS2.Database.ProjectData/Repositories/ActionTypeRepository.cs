using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с типами действий
    /// </summary>
    public class ActionTypeRepository : IVersioningRepository<ActionTypeEntity, short>
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ActionTypeRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionTypeEntity Add(ActionTypeEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionTypes.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionTypeEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionTypes
                .Where(s => s.ActionTypeId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionTypeEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ActionTypes
                .Where(s => s.ActionTypeId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}