using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Тип связи между действиями
    /// </summary>
    public class ActionLinkTypeEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionLinkTypeId">Идентификатор типа связи</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionLinkTypeEntity(short actionLinkTypeId, string name, Guid versionId) : base(versionId)
        {
            ActionLinkTypeId = actionLinkTypeId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionLinkTypeEntity New(string name, Guid versionId)
        {
            return new ActionLinkTypeEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionLinkTypeEntity NewFromExisting(ActionLinkTypeEntity entity, Guid versionId)
        {
            var newEntity = new ActionLinkTypeEntity(entity.ActionLinkTypeId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор типа связи
        /// </summary>
        public short ActionLinkTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}