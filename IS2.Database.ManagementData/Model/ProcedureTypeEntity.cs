using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип процедуры
    /// </summary>
    public class ProcedureTypeEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="procedureTypeId">Идентификатор типа процедуры</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ProcedureTypeEntity(Guid procedureTypeId, string name, Guid versionId) : base(versionId)
        {
            ProcedureTypeId = procedureTypeId;
            Name = name;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ProcedureTypeEntity New(string name, Guid versionId)
        {
            return new ProcedureTypeEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ProcedureTypeEntity NewFromExisting(ProcedureTypeEntity entity, Guid versionId)
        {
            var newEntity = new ProcedureTypeEntity(entity.ProcedureTypeId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

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