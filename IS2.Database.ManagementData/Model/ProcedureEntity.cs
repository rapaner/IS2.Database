using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Процедура
    /// </summary>
    public class ProcedureEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="procedureTypeId">Идентификатор типа процедуры</param>
        /// <param name="stageId">Идентификатор этапа</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ProcedureEntity(Guid procedureId, Guid procedureTypeId, Guid stageId, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId) : base(versionId)
        {
            ProcedureId = procedureId;
            ProcedureTypeId = procedureTypeId;
            StageId = stageId;
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
        /// <param name="procedureTypeId">Идентификатор типа процедуры</param>
        /// <param name="stageId">Идентификатор этапа</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ProcedureEntity New(Guid procedureTypeId, Guid stageId, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId)
        {
            return new ProcedureEntity(default, procedureTypeId, stageId, statusId, dateStartPlan, dateFinishPlan, dateStartFact, dateFinishFact, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ProcedureEntity NewFromExisting(ProcedureEntity entity, Guid versionId)
        {
            var newEntity = new ProcedureEntity(entity.ProcedureId, entity.ProcedureTypeId, entity.StageId, entity.StatusId, entity.DateStartPlan, entity.DateFinishPlan, entity.DateStartFact, entity.DateFinishFact, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор процедуры
        /// </summary>
        public Guid ProcedureId { get; protected set; }

        /// <summary>
        /// Идентификатор типа процедуры
        /// </summary>
        public Guid ProcedureTypeId { get; protected set; }

        /// <summary>
        /// Идентификатор этапа
        /// </summary>
        public Guid StageId { get; protected set; }

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