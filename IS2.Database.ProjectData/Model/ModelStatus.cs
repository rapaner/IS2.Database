using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Статус модели
    /// </summary>
    public class ModelStatus : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="modelStatusId">Идентификатор статуса</param>
        /// <param name="name">Название</param>
        /// <param name="isFinal">Конечный?</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ModelStatus(Guid id, Guid modelStatusId, string name, bool isFinal, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ModelStatusId = modelStatusId;
            Name = name;
            IsFinal = isFinal;
        }

        #endregion Конструкторы

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