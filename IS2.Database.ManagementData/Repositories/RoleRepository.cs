using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с ролями
    /// </summary>
    public class RoleRepository : IVersioningRepository<RoleEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public RoleRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public RoleEntity Add(RoleEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Roles.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RoleEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Roles
                .Where(s => s.RoleId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<RoleEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Roles
                .Where(s => s.RoleId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}