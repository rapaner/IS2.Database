namespace IS2.Database.Common.Model
{
    /// <summary>
    /// Сущность, поддерживающая версионность
    /// </summary>
    public abstract class VersioningEntity
    {
        /// <summary>
        /// Идентификатор версии
        /// </summary>
        public Guid VersionId { get; set; }

        /// <summary>
        /// Дата вставки записи
        /// </summary>
        public DateTime DateInsert { get; set; }

        /// <summary>
        /// Удалена?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}