using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Степень формализации действия
    /// </summary>
    public class ActionFormalization : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="actionFormalizationId">Идентификатор степени формализации действия</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ActionFormalization(Guid id, short actionFormalizationId, string name, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ActionFormalizationId = actionFormalizationId;
            Name = name;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Идентификатор степени формализации действия
        /// </summary>
        public short ActionFormalizationId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}