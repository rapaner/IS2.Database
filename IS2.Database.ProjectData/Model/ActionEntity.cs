using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Действия
    /// </summary>
    public class ActionEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
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
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ActionEntity(Guid id, Guid actionId, string name, Guid projectId, Guid modelId, int localNumber, int level, int number, Guid actionStatusId, Guid actionFormalizationId, Guid actionTypeId, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
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