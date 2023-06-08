using IS2.Database.Common.Contexts;
using IS2.Database.ProjectData.Model;
using IS2.Database.ProjectData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с классами элемента концептуальной структуры
    /// </summary>
    public class ConceptElementClassRepository : IConceptElementClassRepository
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ConceptElementClassRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ConceptElementClassEntity Add(ConceptElementClassEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ConceptElementClasses.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ConceptElementClassEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ConceptElementClasses
                .Where(s => s.ConceptElementClassId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ConceptElementClassEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ConceptElementClasses
                .Where(s => s.ConceptElementClassId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}