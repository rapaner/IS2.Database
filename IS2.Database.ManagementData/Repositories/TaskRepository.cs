using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с задачами
    /// </summary>
    public class TaskRepository : IVersioningRepository<TaskEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public TaskRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public TaskEntity Add(TaskEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Tasks.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TaskEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Tasks
                .Where(s => s.TaskId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<TaskEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Tasks
                .Where(s => s.TaskId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}