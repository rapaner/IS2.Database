using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип этапа
    /// </summary>
    public class StageType : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="stageTypeId">Идентификатор типа этапа</param>
        /// <param name="name">Название</param>
        /// <param name="specificationTemplatePackageId">Идентификатор набора шаблонов спецификаций</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public StageType(Guid id, Guid stageTypeId, string name, Guid specificationTemplatePackageId, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            StageTypeId = stageTypeId;
            Name = name;
            SpecificationTemplatePackageId = specificationTemplatePackageId;
        }

        #endregion Конструктор

        #region Свойства

        /// <summary>
        /// Идентификатор типа этапа
        /// </summary>
        public Guid StageTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Идентификатор набора шаблонов спецификаций
        /// </summary>
        public Guid SpecificationTemplatePackageId { get; protected set; }

        #endregion Свойства
    }
}