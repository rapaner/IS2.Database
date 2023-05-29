using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Модель
    /// </summary>
    public class ModelEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор строки</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="modelTypeId">Идентификатор типа модели</param>
        /// <param name="modelStatusId">Идентификатор статуса модели</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ModelEntity(Guid id, Guid modelId, string name, Guid projectId, Guid modelTypeId, Guid modelStatusId, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ModelId = modelId;
            ProjectId = projectId;
            ModelTypeId = modelTypeId;
            ModelStatusId = modelStatusId;
            Name = name;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Идентификатор модели
        /// </summary>
        public Guid ModelId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Guid ProjectId { get; protected set; }

        /// <summary>
        /// Идентификатор типа модели
        /// </summary>
        public Guid ModelTypeId { get; protected set; }

        /// <summary>
        /// Идентификатор статуса модели
        /// </summary>
        public Guid ModelStatusId { get; protected set; }

        #endregion Свойства
    }
}