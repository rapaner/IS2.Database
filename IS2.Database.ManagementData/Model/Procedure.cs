using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Процедура
    /// </summary>
    public class Procedure : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="procedureTypeId">Идентификатор типа процедуры</param>
        /// <param name="stageId">Идентификатор этапа</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public Procedure(Guid id, Guid procedureId, Guid procedureTypeId, Guid stageId, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
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