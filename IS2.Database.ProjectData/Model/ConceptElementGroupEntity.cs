using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Группа элемента концептуальной структуры
    /// </summary>
    public class ConceptElementGroupEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="conceptElementGroupId">Идентификатор группы</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ConceptElementGroupEntity(short conceptElementGroupId, string name, Guid versionId) : base(versionId)
        {
            ConceptElementGroupId = conceptElementGroupId;
            Name = name;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ConceptElementGroupEntity New(string name, Guid versionId)
        {
            return new ConceptElementGroupEntity(default, name, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ConceptElementGroupEntity NewFromExisting(ConceptElementGroupEntity entity, Guid versionId)
        {
            var newEntity = new ConceptElementGroupEntity(entity.ConceptElementGroupId, entity.Name, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public short ConceptElementGroupId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}