using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Этап
    /// </summary>
    public class StageEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="stageId">Идентификатор этапа</param>
        /// <param name="stageTypeId">Идентификатор типа этапа</param>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public StageEntity(Guid stageId, Guid stageTypeId, Guid taskId, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId) : base(versionId)
        {
            StageId = stageId;
            StageTypeId = stageTypeId;
            TaskId = taskId;
            StatusId = statusId;
            DateStartPlan = dateStartPlan;
            DateFinishPlan = dateFinishPlan;
            DateStartFact = dateStartFact;
            DateFinishFact = dateFinishFact;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="stageTypeId">Идентификатор типа этапа</param>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static StageEntity New(Guid stageTypeId, Guid taskId, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId)
        {
            return new StageEntity(default, stageTypeId, taskId, statusId, dateStartPlan, dateFinishPlan, dateStartFact, dateFinishFact, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static StageEntity NewFromExisting(StageEntity entity, Guid versionId)
        {
            var newEntity = new StageEntity(entity.StageId, entity.StageTypeId, entity.TaskId, entity.StatusId, entity.DateStartPlan, entity.DateFinishPlan, entity.DateStartFact, entity.DateFinishFact, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор этапа
        /// </summary>
        public Guid StageId { get; protected set; }

        /// <summary>
        /// Идентификатор типа этапа
        /// </summary>
        public Guid StageTypeId { get; protected set; }

        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid TaskId { get; protected set; }

        /// <summary>
        /// Код статуса
        /// </summary>
        public short StatusId { get; protected set; }

        /// <summary>
        /// Плановый срок начала
        /// </summary>
        public DateTime DateStartPlan { get; protected set; }

        /// <summary>
        /// Плановый срок окончания
        /// </summary>
        public DateTime DateFinishPlan { get; protected set; }

        /// <summary>
        /// Фактический срок начала
        /// </summary>
        public DateTime? DateStartFact { get; protected set; }

        /// <summary>
        /// Фактический срок окончания
        /// </summary>
        public DateTime? DateFinishFact { get; protected set; }

        #endregion Свойства
    }
}