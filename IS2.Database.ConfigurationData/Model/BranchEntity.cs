namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Ветка
    /// </summary>
    public class BranchEntity
    {
        #region Поля

        /// <summary>
        /// Хэш-код объекта
        /// </summary>
        protected int? _requestedHashCode;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Идентификатор ветки
        /// </summary>
        public Guid BranchId { get; protected set; }

        /// <summary>
        /// Название ветки
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Версии
        /// </summary>
        public List<VersionEntity> Versions { get; } = new();

        /// <summary>
        /// Удалена?
        /// </summary>
        public bool IsDeleted { get; protected set; }

        #endregion Свойства

        #region Методы

        /// <summary>
        /// Установить название
        /// </summary>
        /// <param name="name">Название</param>
        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Установить признак удаления
        /// </summary>
        /// <param name="isDeleted">Удалена?</param>
        public void SetIsDeleted(bool isDeleted = true)
        {
            IsDeleted = isDeleted;
        }

        #endregion Методы

        #region Служебные методы

        /// <summary>
        /// Несохраненный объект
        /// </summary>
        public bool IsTransient()
        {
            return BranchId == default;
        }

        #endregion Служебные методы
    }
}