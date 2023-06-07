using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с проектами
    /// </summary>
    public class ProjectRepository : IVersioningRepository<ProjectEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public ProjectRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ProjectEntity Add(ProjectEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Projects.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProjectEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Projects
                .Where(s => s.ProjectId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ProjectEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Projects
                .Where(s => s.ProjectId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}