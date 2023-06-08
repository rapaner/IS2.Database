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
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="name">Название</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="modelTypeId">Идентификатор типа модели</param>
        /// <param name="modelStatusId">Идентификатор статуса модели</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ModelEntity(Guid modelId, string name, Guid projectId, Guid modelTypeId, Guid modelStatusId, Guid versionId) : base(versionId)
        {
            ModelId = modelId;
            ProjectId = projectId;
            ModelTypeId = modelTypeId;
            ModelStatusId = modelStatusId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="modelTypeId">Идентификатор типа модели</param>
        /// <param name="modelStatusId">Идентификатор статуса модели</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ModelEntity New(string name, Guid projectId, Guid modelTypeId, Guid modelStatusId, Guid versionId)
        {
            return new ModelEntity(default, name, projectId, modelTypeId, modelStatusId, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ModelEntity NewFromExisting(ModelEntity entity, Guid versionId)
        {
            var newEntity = new ModelEntity(entity.ModelId, entity.Name, entity.ProjectId, entity.ModelTypeId, entity.ModelStatusId, versionId);
            return newEntity;
        }

        #endregion Методы

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