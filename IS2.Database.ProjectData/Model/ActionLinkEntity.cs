using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Связь между действиями
    /// </summary>
    public class ActionLinkEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionLinkId">Идентификатор связи</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="linkTypeId">Идентификатор типа связи</param>
        /// <param name="actionId1">Идентификатор первого действия</param>
        /// <param name="actionId2">Идентификатор второго действия</param>
        /// <param name="actionId3">Идентификатор третьего действия</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionLinkEntity(Guid actionLinkId, Guid modelId, Guid linkTypeId, Guid actionId1, Guid actionId2, Guid? actionId3, Guid versionId) : base(versionId)
        {
            ActionLinkId = actionLinkId;
            ModelId = modelId;
            LinkTypeId = linkTypeId;
            ActionId1 = actionId1;
            ActionId2 = actionId2;
            ActionId3 = actionId3;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="linkTypeId">Идентификатор типа связи</param>
        /// <param name="actionId1">Идентификатор первого действия</param>
        /// <param name="actionId2">Идентификатор второго действия</param>
        /// <param name="actionId3">Идентификатор третьего действия</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionLinkEntity New(Guid modelId, Guid linkTypeId, Guid actionId1, Guid actionId2, Guid? actionId3, Guid versionId)
        {
            return new ActionLinkEntity(default, modelId, linkTypeId, actionId1, actionId2, actionId3, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionLinkEntity NewFromExisting(ActionLinkEntity entity, Guid versionId)
        {
            var newEntity = new ActionLinkEntity(entity.ActionLinkId, entity.ModelId, entity.LinkTypeId, entity.ActionId1, entity.ActionId2, entity.ActionId3, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентфикатор связи
        /// </summary>
        public Guid ActionLinkId { get; protected set; }

        /// <summary>
        /// Идентификатор модели
        /// </summary>
        public Guid ModelId { get; protected set; }

        /// <summary>
        /// Идентификатор типа связи
        /// </summary>
        public Guid LinkTypeId { get; protected set; }

        /// <summary>
        /// Идентификатор первого действия
        /// </summary>
        public Guid ActionId1 { get; protected set; }

        /// <summary>
        /// Идентификатор второго действия
        /// </summary>
        public Guid ActionId2 { get; protected set; }

        /// <summary>
        /// Идентификатор третьего действия
        /// </summary>
        public Guid? ActionId3 { get; protected set; }

        #endregion Свойства
    }
}