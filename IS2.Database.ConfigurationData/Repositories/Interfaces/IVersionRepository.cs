using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;

namespace IS2.Database.ConfigurationData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с версиями
    /// </summary>
    public interface IVersionRepository
    {
        /// <summary>
        /// Объект для сохранения данных
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Получить версию по идентификатору
        /// </summary>
        /// <param name="versionId">Идентификатор версии</param>
        Task<VersionEntity> FindVersionById(Guid versionId);

        /// <summary>
        /// Добавить новую версию
        /// </summary>
        VersionEntity Add(VersionEntity version);

        /// <summary>
        /// Обновить версию
        /// </summary>
        /// <param name="version">Версия</param>
        VersionEntity Update(VersionEntity version);
    }
}