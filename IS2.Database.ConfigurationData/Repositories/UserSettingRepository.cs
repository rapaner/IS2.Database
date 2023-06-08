using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;
using IS2.Database.ConfigurationData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий настроек пользователей
    /// </summary>
    public class UserSettingRepository : IUserSettingRepository
    {
        private readonly ConfigurationDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public UserSettingRepository(ConfigurationDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public UserSettingEntity Add(UserSettingEntity userSetting)
        {
            if (userSetting.IsTransient())
            {
                return _context.UserSettings.Add(userSetting).Entity;
            }

            return userSetting;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserSettingEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var userSettings = await _context.UserSettings
                .Where(s => s.SettingId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return userSettings;
        }

        /// <inheritdoc/>
        public async Task<UserSettingEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var userSetting = await _context.UserSettings
                .Where(s => s.SettingId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return userSetting;
        }
    }
}