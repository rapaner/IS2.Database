using IS2.Database.Common.Contexts;
using IS2.Database.Common.Model;

namespace IS2.Database.Common.Repositories
{
    /// <summary>
    /// Интерфейс базовых операций с версионными сущностями
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVersioningRepository<T> where T : VersioningEntity
    {
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
        Task<T> FindByIdAndVersionId(Guid entityId, Guid versionId);

        /// <summary>
        /// Найти все версии сущности
        /// </summary>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <param name="versionIds">Список версий</param>
        Task<IEnumerable<T>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds);
    }
}