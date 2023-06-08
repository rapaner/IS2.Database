using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с группами элемента концептуальной структуры
    /// </summary>
    public class ConceptElementGroupRepository : IVersioningRepository<ConceptElementGroupEntity, short>
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ConceptElementGroupRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ConceptElementGroupEntity Add(ConceptElementGroupEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ConceptElementGroups.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ConceptElementGroupEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ConceptElementGroups
                .Where(s => s.ConceptElementGroupId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ConceptElementGroupEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ConceptElementGroups
                .Where(s => s.ConceptElementGroupId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}