using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с типами связей между действиями
    /// </summary>
    public class ActionLinkTypeRepository : IVersioningRepository<ActionLinkTypeEntity, short>
    {
        private readonly ProjectDataContext _context;

        public ActionLinkTypeRepository(ProjectDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionLinkTypeEntity Add(ActionLinkTypeEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionLinkTypes.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionLinkTypeEntity>> FindAllVersionsById(short entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionLinkTypes
                .Where(s => s.ActionLinkTypeId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionLinkTypeEntity> FindByIdAndVersionId(short entityId, Guid versionId)
        {
            var setting = await _context.ActionLinkTypes
                .Where(s => s.ActionLinkTypeId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}