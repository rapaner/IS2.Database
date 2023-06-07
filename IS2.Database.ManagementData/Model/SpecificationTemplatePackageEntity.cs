using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Набор шаблонов спецификаций
    /// </summary>
    public class SpecificationTemplatePackageEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="specificationTemplatePackageId">Идентификатор набора</param>
        /// <param name="name">Название</param>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="versionId">Идентификатор версии</param>
        public SpecificationTemplatePackageEntity(Guid specificationTemplatePackageId, string name, string tableName, Guid versionId) : base(versionId)
        {
            SpecificationTemplatePackageId = specificationTemplatePackageId;
            Name = name;
            TableName = tableName;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static SpecificationTemplatePackageEntity New(string name, string tableName, Guid versionId)
        {
            return new SpecificationTemplatePackageEntity(default, name, tableName, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static SpecificationTemplatePackageEntity NewFromExisting(SpecificationTemplatePackageEntity entity, Guid versionId)
        {
            var newEntity = new SpecificationTemplatePackageEntity(entity.SpecificationTemplatePackageId, entity.Name, entity.TableName, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор набора
        /// </summary>
        public Guid SpecificationTemplatePackageId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Название таблицы
        /// </summary>
        public string TableName { get; protected set; }

        #endregion Свойства
    }
}