using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Концептуальная структура
    /// </summary>
    public class ConceptElementEntity : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="conceptElementId">Идентификатор элемента концептуальной структуры</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="name">Название</param>
        /// <param name="conceptElementClassId">Идентификатор класса</param>
        /// <param name="conceptElementGroupId"></param>
        /// <param name="number">Номер</param>
        /// <param name="isAutoRange">Автонумерация</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ConceptElementEntity(Guid conceptElementId, Guid modelId, string name, Guid conceptElementClassId, Guid conceptElementGroupId, int number, bool isAutoRange, Guid versionId) : base(versionId)
        {
            ConceptElementId = conceptElementId;
            ModelId = modelId;
            Name = name;
            ConceptElementClassId = conceptElementClassId;
            ConceptElementGroupId = conceptElementGroupId;
            Number = number;
            IsAutoRange = isAutoRange;
        }

        #endregion Конструктор

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="name">Название</param>
        /// <param name="conceptElementClassId">Идентификатор класса</param>
        /// <param name="conceptElementGroupId"></param>
        /// <param name="number">Номер</param>
        /// <param name="isAutoRange">Автонумерация</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ConceptElementEntity New(Guid modelId, string name, Guid conceptElementClassId, Guid conceptElementGroupId, int number, bool isAutoRange, Guid versionId)
        {
            return new ConceptElementEntity(default, modelId, name, conceptElementClassId, conceptElementGroupId, number, isAutoRange, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ConceptElementEntity NewFromExisting(ConceptElementEntity entity, Guid versionId)
        {
            var newEntity = new ConceptElementEntity(entity.ConceptElementId, entity.ModelId, entity.Name, entity.ConceptElementClassId, entity.ConceptElementGroupId, entity.Number, entity.IsAutoRange, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор элемента концептуальной структуры
        /// </summary>
        public Guid ConceptElementId { get; protected set; }

        /// <summary>
        /// Идентификатор модели
        /// </summary>
        public Guid ModelId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Идентификатор класса
        /// </summary>
        public Guid ConceptElementClassId { get; protected set; }

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid ConceptElementGroupId { get; protected set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; protected set; }

        /// <summary>
        /// Автонумерация
        /// </summary>
        public bool IsAutoRange { get; protected set; }

        #endregion Свойства
    }
}