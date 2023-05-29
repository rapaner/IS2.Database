using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    public class User : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="email">Почта</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public User(Guid id, Guid userId, string lastName, string firstName, string middleName, string email, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            UserId = userId;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Email = email;
        }

        #endregion Конструктор

        #region Свойства

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; protected set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; protected set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; protected set; }

        #endregion Свойства
    }
}