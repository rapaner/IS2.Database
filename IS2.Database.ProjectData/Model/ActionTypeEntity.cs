using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Тип действия
    /// </summary>
    public class ActionTypeEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionTypeId">Идентификатор типа действия</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionTypeEntity(short actionTypeId, string name, Guid versionId) : base(versionId)
        {
            ActionTypeId = actionTypeId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionTypeEntity New(string name, Guid versionId)
        {
            return new ActionTypeEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionTypeEntity NewFromExisting(ActionTypeEntity entity, Guid versionId)
        {
            var newEntity = new ActionTypeEntity(entity.ActionTypeId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор типа действия
        /// </summary>
        public short ActionTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}