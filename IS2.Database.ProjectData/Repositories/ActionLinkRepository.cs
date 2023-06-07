using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы со связями между действиями
    /// </summary>
    public class ActionLinkRepository : IVersioningRepository<ActionLinkEntity, Guid>
    {
        private readonly ProjectDataContext _context;

        public ActionLinkRepository(ProjectDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionLinkEntity Add(ActionLinkEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionLinks.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionLinkEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionLinks
                .Where(s => s.ActionLinkId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionLinkEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ActionLinks
                .Where(s => s.ActionLinkId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}