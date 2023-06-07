using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип доступности процедуры
    /// </summary>
    public class ProcedureAvailabilityTypeEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="procedureAvailabilityTypeId">Идентификатор типа доступности процедуры</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        protected ProcedureAvailabilityTypeEntity(Guid procedureAvailabilityTypeId, string name, Guid versionId) : base(versionId)
        {
            ProcedureAvailabilityTypeId = procedureAvailabilityTypeId;
            Name = name;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ProcedureAvailabilityTypeEntity New(string name, Guid versionId)
        {
            return new ProcedureAvailabilityTypeEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ProcedureAvailabilityTypeEntity NewFromExisting(ProcedureAvailabilityTypeEntity entity, Guid versionId)
        {
            var newEntity = new ProcedureAvailabilityTypeEntity(entity.ProcedureAvailabilityTypeId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

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