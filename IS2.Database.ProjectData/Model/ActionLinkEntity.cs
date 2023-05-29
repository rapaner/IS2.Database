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
        /// <param name="id">Идентификатор</param>
        /// <param name="actionLinkId">Идентификатор связи</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="linkTypeId">Идентификатор типа связи</param>
        /// <param name="actionId1">Идентификатор первого действия</param>
        /// <param name="actionId2">Идентификатор второго действия</param>
        /// <param name="actionId3">Идентификатор третьего действия</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ActionLinkEntity(Guid id, Guid actionLinkId, Guid modelId, Guid linkTypeId, Guid actionId1, Guid actionId2, Guid? actionId3, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ActionLinkId = actionLinkId;
            ModelId = modelId;
            LinkTypeId = linkTypeId;
            ActionId1 = actionId1;
            ActionId2 = actionId2;
            ActionId3 = actionId3;
        }

        #endregion Конструкторы

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