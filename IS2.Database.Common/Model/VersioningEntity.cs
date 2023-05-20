namespace IS2.Database.Common.Model
{
    /// <summary>
    /// Сущность, поддерживающая версионность
    /// </summary>
    public abstract class VersioningEntity
    {
        #region Поля

        protected int? _requestedHashCode;

        #endregion Поля

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор строки</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        protected VersioningEntity(Guid id, Guid versionId, DateTime dateInsert, bool isDeleted)
        {
            Id = id;
            VersionId = versionId;
            DateInsert = dateInsert;
            IsDeleted = isDeleted;
        }

        #region Свойства

        /// <summary>
        /// Идентификатор строки
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Идентификатор версии
        /// </summary>
        public Guid VersionId { get; protected set; }

        /// <summary>
        /// Дата вставки записи
        /// </summary>
        public DateTime DateInsert { get; protected set; }

        /// <summary>
        /// Удалена?
        /// </summary>
        public bool IsDeleted { get; protected set; }

        #endregion Свойства

        #region Методы изменения свойств

        /// <summary>
        /// Установить код версии
        /// </summary>
        /// <param name="versionId">Код версии</param>
        public void SetVersionId(Guid versionId)
        {
            VersionId = versionId;
        }

        /// <summary>
        /// Установить дату вставки
        /// </summary>
        /// <param name="dateInsert">Дата вставки</param>
        public void SetDateInsert(DateTime dateInsert)
        {
            DateInsert = dateInsert;
        }

        /// <summary>
        /// Установить признак удаления
        /// </summary>
        /// <param name="isDeleted">Удалена?</param>
        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        #endregion Методы изменения свойств
    }
}