using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="email">Почта</param>
        /// <param name="versionId">Идентификатор версии</param>
        public UserEntity(Guid userId, string lastName, string firstName, string middleName, string email, Guid versionId) : base(versionId)
        {
            UserId = userId;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Email = email;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="email">Почта</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static UserEntity New(string lastName, string firstName, string middleName, string email, Guid versionId)
        {
            return new UserEntity(default, lastName, firstName, middleName, email, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static UserEntity NewFromExisting(UserEntity entity, Guid versionId)
        {
            var newEntity = new UserEntity(entity.UserId, entity.LastName, entity.FirstName, entity.MiddleName, entity.Email, versionId);
            return newEntity;
        }

        #endregion Методы

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