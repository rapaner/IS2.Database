using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Статус модели
    /// </summary>
    public class ModelStatusEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="modelStatusId">Идентификатор статуса</param>
        /// <param name="name">Название</param>
        /// <param name="isFinal">Конечный?</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ModelStatusEntity(Guid modelStatusId, string name, bool isFinal, Guid versionId) : base(versionId)
        {
            ModelStatusId = modelStatusId;
            Name = name;
            IsFinal = isFinal;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="isFinal">Конечный?</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ModelStatusEntity New(string name, bool isFinal, Guid versionId)
        {
            return new ModelStatusEntity(default, name, isFinal, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ModelStatusEntity NewFromExisting(ModelStatusEntity entity, Guid versionId)
        {
            var newEntity = new ModelStatusEntity(entity.ModelStatusId, entity.Name, entity.IsFinal, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Статус модели
        /// </summary>
        public Guid ModelStatusId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Конечный?
        /// </summary>
        public bool IsFinal { get; protected set; }

        #endregion Свойства
    }
}