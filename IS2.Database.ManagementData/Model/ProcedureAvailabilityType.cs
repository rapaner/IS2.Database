using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип доступности процедуры
    /// </summary>
    public class ProcedureAvailabilityType : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="procedureAvailabilityTypeId">Идентификатор типа доступности процедуры</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ProcedureAvailabilityType(Guid id, Guid procedureAvailabilityTypeId, string name, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ProcedureAvailabilityTypeId = procedureAvailabilityTypeId;
            Name = name;
        }

        #endregion Конструктор

        #region Свойства

        /// <summary>
        /// Идентификатор типа доступности процедуры
        /// </summary>
        public Guid ProcedureAvailabilityTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}