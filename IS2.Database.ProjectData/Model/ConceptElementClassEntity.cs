using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Класс элемента концептуальной структуры
    /// </summary>
    public class ConceptElementClassEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="conceptElementClassId">Идентификатор класса</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ConceptElementClassEntity(short conceptElementClassId, string name, Guid versionId) : base(versionId)
        {
            ConceptElementClassId = conceptElementClassId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ConceptElementClassEntity New(string name, Guid versionId)
        {
            return new ConceptElementClassEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ConceptElementClassEntity NewFromExisting(ConceptElementClassEntity entity, Guid versionId)
        {
            var newEntity = new ConceptElementClassEntity(entity.ConceptElementClassId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор класса
        /// </summary>
        public short ConceptElementClassId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}