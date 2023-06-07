using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Тип этапа
    /// </summary>
    public class StageTypeEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="stageTypeId">Идентификатор типа этапа</param>
        /// <param name="name">Название</param>
        /// <param name="specificationTemplatePackageId">Идентификатор набора шаблонов спецификаций</param>
        /// <param name="versionId">Идентификатор версии</param>
        public StageTypeEntity(Guid stageTypeId, string name, Guid specificationTemplatePackageId, Guid versionId) : base(versionId)
        {
            StageTypeId = stageTypeId;
            Name = name;
            SpecificationTemplatePackageId = specificationTemplatePackageId;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="specificationTemplatePackageId">Идентификатор набора шаблонов спецификаций</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static StageTypeEntity New(string name, Guid specificationTemplatePackageId, Guid versionId)
        {
            return new StageTypeEntity(default, name, specificationTemplatePackageId, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static StageTypeEntity NewFromExisting(StageTypeEntity entity, Guid versionId)
        {
            var newEntity = new StageTypeEntity(entity.StageTypeId, entity.Name, entity.SpecificationTemplatePackageId, versionId);
            return newEntity;
        }

        #endregion Методы

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