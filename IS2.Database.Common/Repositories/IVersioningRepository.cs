using IS2.Database.Common.Contexts;
using IS2.Database.Common.Model;

namespace IS2.Database.Common.Repositories
{
    /// <summary>
    /// Интерфейс базовых операций с версионными сущностями
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="U">Тип идентификатора сущности</typeparam>
    public interface IVersioningRepository<T, U> where T : VersioningEntity
    {
        /// <summary>
        /// Объект для сохранения данных
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="entity">Сущность</param>
        T Add(T entity);

        /// <summary>
        /// Найти определенную версию сущности
        /// </summary>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <param name="versionId">Идентификатор версии</param>
        Task<T> FindByIdAndVersionId(U entityId, Guid versionId);

        /// <summary>
        /// Найти все версии сущности
        /// </summary>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <param name="versionIds">Список версий</param>
        Task<IEnumerable<T>> FindAllVersionsById(U entityId, IEnumerable<Guid> versionIds);
    }
}