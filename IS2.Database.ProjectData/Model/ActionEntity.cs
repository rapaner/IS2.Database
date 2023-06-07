using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Действие
    /// </summary>
    public class ActionEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="actionId">Идентификатор действия</param>
        /// <param name="name">Название</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="localNumber">Номер в модели</param>
        /// <param name="level">Уровень</param>
        /// <param name="number">Номер на уровне</param>
        /// <param name="actionStatusId">Идентификатор статуса</param>
        /// <param name="actionFormalizationId">Идентификатор степени формализации</param>
        /// <param name="actionTypeId">Идентификатор типа</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ActionEntity(Guid actionId, string name, Guid projectId, Guid modelId, int localNumber, int level, int number, Guid actionStatusId, Guid actionFormalizationId, Guid actionTypeId, Guid versionId) : base(versionId)
        {
            ActionId = actionId;
            Name = name;
            ProjectId = projectId;
            ModelId = modelId;
            LocalNumber = localNumber;
            Level = level;
            Number = number;
            ActionStatusId = actionStatusId;
            ActionFormalizationId = actionFormalizationId;
            ActionTypeId = actionTypeId;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="localNumber">Номер в модели</param>
        /// <param name="level">Уровень</param>
        /// <param name="number">Номер на уровне</param>
        /// <param name="actionStatusId">Идентификатор статуса</param>
        /// <param name="actionFormalizationId">Идентификатор степени формализации</param>
        /// <param name="actionTypeId">Идентификатор типа</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ActionEntity New(string name, Guid projectId, Guid modelId, int localNumber, int level, int number, Guid actionStatusId, Guid actionFormalizationId, Guid actionTypeId, Guid versionId)
        {
            return new ActionEntity(default, name, projectId, modelId, localNumber, level, number, actionStatusId, actionFormalizationId, actionTypeId, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ActionEntity NewFromExisting(ActionEntity entity, Guid versionId)
        {
            var newEntity = new ActionEntity(entity.ActionId, entity.Name, entity.ProjectId, entity.ModelId, entity.LocalNumber, entity.Level, entity.Number, entity.ActionStatusId, entity.ActionFormalizationId, entity.ActionTypeId, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор действия
        /// </summary>
        public Guid ActionId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Guid ProjectId { get; protected set; }

        /// <summary>
        /// Идентификатор модели
        /// </summary>
        public Guid ModelId { get; protected set; }

        /// <summary>
        /// Номер в модели
        /// </summary>
        public int LocalNumber { get; protected set; }

        /// <summary>
        /// Уровень
        /// </summary>
        public int Level { get; protected set; }

        /// <summary>
        /// Номер на уровне
        /// </summary>
        public int Number { get; protected set; }

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        public Guid ActionStatusId { get; protected set; }

        /// <summary>
        /// Идентификатор степени формализации
        /// </summary>
        public Guid ActionFormalizationId { get; protected set; }

        /// <summary>
        /// Идентификатор типа
        /// </summary>
        public Guid ActionTypeId { get; protected set; }

        #endregion Свойства
    }
}