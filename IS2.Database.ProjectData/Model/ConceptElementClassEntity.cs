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
        /// <param name="id">Идентификатор</param>
        /// <param name="conceptElementClassId">Идентификатор класса</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ConceptElementClassEntity(Guid id, short conceptElementClassId, string name, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ConceptElementClassId = conceptElementClassId;
            Name = name;
        }

        #endregion Конструкторы

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