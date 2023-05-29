using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Взаимосвязь процедуры и модуля
    /// </summary>
    public class ProcedureToModule : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="moduleId">Идентификатор модуля</param>
        /// <param name="procedureAvailabilityTypeId">Идентификатор типа доступности процедуры</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ProcedureToModule(Guid id, Guid procedureId, Guid moduleId, Guid procedureAvailabilityTypeId, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ProcedureId = procedureId;
            ModuleId = moduleId;
            ProcedureAvailabilityTypeId = procedureAvailabilityTypeId;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Идентификатор процедуры
        /// </summary>
        public Guid ProcedureId { get; protected set; }

        /// <summary>
        /// Идентификатор модуля
        /// </summary>
        public Guid ModuleId { get; protected set; }

        /// <summary>
        /// Идентификатор типа доступности процедуры
        /// </summary>
        public Guid ProcedureAvailabilityTypeId { get; protected set; }

        #endregion Свойства
    }
}