using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Концептуальная структура
    /// </summary>
    public class ConceptElement : VersioningEntity
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор строки</param>
        /// <param name="conceptElementId">Идентификатор элемента концептуальной структуры</param>
        /// <param name="modelId">Идентификатор модели</param>
        /// <param name="name">Название</param>
        /// <param name="conceptElementClassId">Идентификатор класса</param>
        /// <param name="conceptElementGroupId"></param>
        /// <param name="number">Номер</param>
        /// <param name="isAutoRange">Автонумерация</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ConceptElement(Guid id, Guid conceptElementId, Guid modelId, string name, Guid conceptElementClassId, Guid conceptElementGroupId, int number, bool isAutoRange, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
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