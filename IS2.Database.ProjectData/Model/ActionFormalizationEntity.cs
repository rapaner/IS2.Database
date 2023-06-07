using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Степень формализации действия
    /// </summary>
    public class ActionFormalizationEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionFormalizationId">Идентификатор степени формализации действия</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionFormalizationEntity(short actionFormalizationId, string name, Guid versionId) : base(versionId)
        {
            ActionFormalizationId = actionFormalizationId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionFormalizationEntity New(string name, Guid versionId)
        {
            return new ActionFormalizationEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionFormalizationEntity NewFromExisting(ActionFormalizationEntity entity, Guid versionId)
        {
            var newEntity = new ActionFormalizationEntity(entity.ActionFormalizationId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор степени формализации действия
        /// </summary>
        public short ActionFormalizationId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}