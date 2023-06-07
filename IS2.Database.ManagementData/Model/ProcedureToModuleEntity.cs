using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Взаимосвязь процедуры и модуля
    /// </summary>
    public class ProcedureToModuleEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="procedureToModuleId">Идентификатор связи</param>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="moduleId">Идентификатор модуля</param>
        /// <param name="procedureAvailabilityTypeId">Идентификатор типа доступности процедуры</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ProcedureToModuleEntity(Guid procedureToModuleId, Guid procedureId, Guid moduleId, Guid procedureAvailabilityTypeId, Guid versionId) : base(versionId)
        {
            ProcedureToModuleId = procedureToModuleId;
            ProcedureId = procedureId;
            ModuleId = moduleId;
            ProcedureAvailabilityTypeId = procedureAvailabilityTypeId;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="moduleId">Идентификатор модуля</param>
        /// <param name="procedureAvailabilityTypeId">Идентификатор типа доступности процедуры</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ProcedureToModuleEntity New(Guid procedureId, Guid moduleId, Guid procedureAvailabilityTypeId, Guid versionId)
        {
            return new ProcedureToModuleEntity(default, procedureId, moduleId, procedureAvailabilityTypeId, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ProcedureToModuleEntity NewFromExisting(ProcedureToModuleEntity entity, Guid versionId)
        {
            var newEntity = new ProcedureToModuleEntity(entity.ProcedureToModuleId, entity.ProcedureId, entity.ModuleId, entity.ProcedureAvailabilityTypeId, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор связи
        /// </summary>
        public Guid ProcedureToModuleId { get; protected set; }

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