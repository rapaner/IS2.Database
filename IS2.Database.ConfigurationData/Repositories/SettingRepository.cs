using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий настроек
    /// </summary>
    public class SettingRepository : IVersioningRepository<SettingEntity, Guid>
    {
        private readonly ConfigurationDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public SettingRepository(ConfigurationDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public SettingEntity Add(SettingEntity setting)
        {
            if (setting.IsTransient())
            {
                return _context.Settings.Add(setting).Entity;
            }

            return setting;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SettingEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Settings
                .Where(s => s.SettingId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<SettingEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Settings
                .Where(s => s.SettingId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}