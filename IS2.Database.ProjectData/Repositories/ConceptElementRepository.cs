using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с элементами концептуальной структуры
    /// </summary>
    public class ConceptElementRepository : IVersioningRepository<ConceptElementEntity, Guid>
    {
        private readonly ProjectDataContext _context;

        public ConceptElementRepository(ProjectDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ConceptElementEntity Add(ConceptElementEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ConceptElements.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ConceptElementEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ConceptElements
                .Where(s => s.ConceptElementId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ConceptElementEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ConceptElements
                .Where(s => s.ConceptElementId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}