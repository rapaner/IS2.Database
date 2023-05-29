using IS2.Database.Common.Model;

namespace IS2.Database.ProjectData.Model
{
    /// <summary>
    /// Тип статуса
    /// </summary>
    public class ActionStatus : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="actionStatusId">Идентификатор типа статуса</param>
        /// <param name="name">Название</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public ActionStatus(Guid id, short actionStatusId, string name, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            ActionStatusId = actionStatusId;
            Name = name;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Идентификатор типа статуса
        /// </summary>
        public short ActionStatusId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        #endregion Свойства
    }
}