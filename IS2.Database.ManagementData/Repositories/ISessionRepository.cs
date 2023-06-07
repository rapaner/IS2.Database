using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с сессиями
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Добавить объект
        /// </summary>
        /// <param name="entity">Объект</param>
        SessionEntity Add(SessionEntity entity);
    }
}