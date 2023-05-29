using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип процедуры
    /// </summary>
    public class ProcedureType : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="procedureTypeId">Идентификатор типа процедуры</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ProcedureType(Guid id, Guid procedureTypeId, string name, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ProcedureTypeId = procedureTypeId;
            Name = name;
        }

        #endregion Конструктор

        #region Свойства

        /// <summary>
        /// Идентификатор типа процедуры
        /// </summary>
        public Guid ProcedureTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}