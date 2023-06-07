using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Роль
    /// </summary>
    public class RoleEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public RoleEntity(Guid roleId, string name, Guid versionId) : base(versionId)
        {
            RoleId = roleId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static RoleEntity New(string name, Guid versionId)
        {
            return new RoleEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static RoleEntity NewFromExisting(RoleEntity entity, Guid versionId)
        {
            var newEntity = new RoleEntity(entity.RoleId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public Guid RoleId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}