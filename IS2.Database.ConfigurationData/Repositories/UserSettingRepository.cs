﻿using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий настроек
    /// </summary>
    public class UserSettingRepository : IVersioningRepository<UserSettingEntity>
    {
        private readonly ConfigurationDataContext _context;
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