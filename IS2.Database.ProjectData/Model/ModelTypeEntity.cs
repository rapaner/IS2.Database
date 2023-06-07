using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Тип модели
    /// </summary>
    public class ModelTypeEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="modelTypeId">Идентификатор типа</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ModelTypeEntity(Guid modelTypeId, string name, Guid versionId) : base(versionId)
        {
            ModelTypeId = modelTypeId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ModelTypeEntity New(string name, Guid versionId)
        {
            return new ModelTypeEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ModelTypeEntity NewFromExisting(ModelTypeEntity entity, Guid versionId)
        {
            var newEntity = new ModelTypeEntity(entity.ModelTypeId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Тип модели
        /// </summary>
        public Guid ModelTypeId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}