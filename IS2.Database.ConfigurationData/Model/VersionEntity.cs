namespace IS2.Database.ConfigurationData.Model
{
    /// <summary>
    /// Версия
    /// </summary>
    public class VersionEntity
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
        /// <param name="versionType">Тип версии</param>
        /// <param name="previousVersionId">Идентификатор предыдущей версии</param>
        /// <param name="branchId">Идентификатор ветки</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="versionDate">Дата версии</param>
        /// <param name="name">Название версии</param>
        /// <param name="comment">Комментарий</param>
        public VersionEntity(VersionTypeEntity versionType, Guid? previousVersionId, Guid branchId, Guid userId, DateTime versionDate, string name, string comment)
        {
            VersionType = versionType;
            PreviousVersionId = previousVersionId;
            BranchId = branchId;
            UserId = userId;
            VersionDate = versionDate;
            Name = name;
            Comment = comment;
        }

        #region Свойства

        /// <summary>
        /// Идентификатор версии
        /// </summary>
        public Guid VersionId { get; protected set; }

        /// <summary>
        /// Тип версии
        /// </summary>
        public VersionTypeEntity VersionType { get; protected set; }

        /// <summary>
        /// Идентификатор предыдущей версии
        /// </summary>
        public Guid? PreviousVersionId { get; protected set; }

        /// <summary>
        /// Идентификатор ветки
        /// </summary>
        public Guid BranchId { get; protected set; }

        /// <summary>
        /// Ветка
        /// </summary>
        public BranchEntity Branch { get; protected set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; protected set; }

        /// <summary>
        /// Дата версии
        /// </summary>
        public DateTime VersionDate { get; protected set; }

        /// <summary>
        /// Название версии
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; protected set; }

        #endregion Свойства

        #region Методы изменения свойств

        /// <summary>
        /// Установить тип версии
        /// </summary>
        /// <param name="versionType">Тип версии</param>
        public void SetVersionTypeId(VersionTypeEntity versionType)
        {
            VersionType = versionType;
        }

        /// <summary>
        /// Установить идентификатор предыдущей версии
        /// </summary>
        /// <param name="previousVersionId">Идентификатор пердыдущей версии</param>
        public void SetPreviousVersionId(Guid? previousVersionId)
        {
            PreviousVersionId = previousVersionId;
        }

        /// <summary>
        /// Установить идентификатор ветки
        /// </summary>
        /// <param name="branchId">Идентификатор ветки</param>
        public void SetBranchId(Guid branchId)
        {
            BranchId = branchId;
        }

        /// <summary>
        /// Установить идентификатор пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        public void SetUserId(Guid userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// Установить дату версии
        /// </summary>
        /// <param name="versionDate">Дата версии</param>
        public void SetVersionDate(DateTime versionDate)
        {
            VersionDate = versionDate;
        }

        /// <summary>
        /// Установить название версии
        /// </summary>
        /// <param name="name">Название версии</param>
        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Установить комменатрий
        /// </summary>
        /// <param name="comment">Комментарий</param>
        public void SetComment(string comment)
        {
            Comment = comment;
        }

        #endregion Методы изменения свойств

        #region Служебные методы

        /// <summary>
        /// Несохраненный объект
        /// </summary>
        public bool IsTransient()
        {
            return VersionId == default;
        }

        #endregion Служебные методы
    }
}