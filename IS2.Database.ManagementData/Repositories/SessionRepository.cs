using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с сессиями
    /// </summary>
    public class SessionRepository : ISessionRepository
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public SessionRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public SessionEntity Add(SessionEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Sessions.Add(entity).Entity;
            }

            return entity;
        }
    }
}