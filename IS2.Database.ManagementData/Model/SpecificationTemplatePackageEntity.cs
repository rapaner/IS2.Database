using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Набор шаблонов спецификаций
    /// </summary>
    public class SpecificationTemplatePackage : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="specificationTemplatePackageId">Идентификатор набора</param>
        /// <param name="name">Название</param>
        /// <param name="tableName">Название таблицы</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки</param>
        /// <param name="isDeleted">Удалена?</param>
        public SpecificationTemplatePackage(Guid id, Guid specificationTemplatePackageId, string name, string tableName, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            SpecificationTemplatePackageId = specificationTemplatePackageId;
            Name = name;
            TableName = tableName;
        }

        #endregion Конструктор

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