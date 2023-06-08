namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Сессия
    /// </summary>
    public class SessionEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="assignmentId">Идентификатор назначения</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        public SessionEntity(Guid assignmentId, DateTime dateStart, DateTime? dateFinish)
        {
            AssignmentId = assignmentId;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="assignmentId">Идентификатор назначения</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        public static SessionEntity New(Guid assignmentId, DateTime dateStart, DateTime? dateFinish)
        {
            return new SessionEntity(assignmentId, dateStart, dateFinish);
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор сессии
        /// </summary>
        public Guid SessionId { get; protected set; }

        /// <summary>
        /// Идентификатор назначения
        /// </summary>
        public Guid AssignmentId { get; protected set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; protected set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? DateFinish { get; protected set; }

        #endregion Свойства

        #region Служебные методы

        /// <summary>
        /// Несохраненный объект
        /// </summary>
        public bool IsTransient()
        {
            return SessionId == default;
        }

        #endregion Служебные методы
    }
}