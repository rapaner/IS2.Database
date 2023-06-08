namespace IS2.Database.Common.Model
{
    /// <summary>
    /// Сущность, поддерживающая версионность
    /// </summary>
    public abstract class VersioningEntity
    {
        #region Поля

        /// <summary>
        /// Хэш-код объекта
        /// </summary>
        protected int? _requestedHashCode;

        #endregion Поля

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="versionId">Идентификатор версии</param>
        protected VersioningEntity(Guid versionId)
        {
            VersionId = versionId;
            DateInsert = DateTime.Now;
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

        #region Служебные методы

        /// <summary>
        /// Несохраненный объект
        /// </summary>
        public bool IsTransient()
        {
            return Id == default;
        }

        #endregion Служебные методы
    }
}