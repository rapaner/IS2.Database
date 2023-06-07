using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Тип статуса действия
    /// </summary>
    public class ActionStatusEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionStatusId">Идентификатор типа статуса действия</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionStatusEntity(short actionStatusId, string name, Guid versionId) : base(versionId)
        {
            ActionStatusId = actionStatusId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionStatusEntity New(string name, Guid versionId)
        {
            return new ActionStatusEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionStatusEntity NewFromExisting(ActionStatusEntity entity, Guid versionId)
        {
            var newEntity = new ActionStatusEntity(entity.ActionStatusId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор типа статуса
        /// </summary>
        public short ActionStatusId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}