using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.Model;
using IS2.Database.ManagementData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с пользователями
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public UserRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public UserEntity Add(UserEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Users.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Users
                .Where(s => s.UserId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<UserEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Users
                .Where(s => s.UserId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}