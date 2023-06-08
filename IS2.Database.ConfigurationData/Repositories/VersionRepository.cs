using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;
using IS2.Database.ConfigurationData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий работы с версиями
    /// </summary>
    public class VersionRepository : IVersionRepository
    {
        private readonly ConfigurationDataContext _context;

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public VersionRepository(ConfigurationDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public VersionEntity Add(VersionEntity version)
        {
            if (version.IsTransient())
            {
                return _context.Versions.Add(version).Entity;
            }

            return version;
        }

        /// <inheritdoc/>
        public VersionEntity Update(VersionEntity version)
        {
            return _context.Versions.Update(version).Entity;
        }

        /// <inheritdoc/>
        public async Task<VersionEntity> FindVersionById(Guid versionId)
        {
            var version = await _context.Versions.FirstOrDefaultAsync(v => v.VersionId == versionId);
            return version;
        }
    }
}