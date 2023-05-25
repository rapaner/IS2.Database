namespace IS2.Database.ManagementData.Model
{
    public class Session
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sessionId">Идентификатор сессии</param>
        /// <param name="assignmentId">Идентификатор назначения</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        public Session(Guid sessionId, Guid assignmentId, DateTime dateStart, DateTime? dateFinish)
        {
            SessionId = sessionId;
            AssignmentId = assignmentId;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }

        #endregion Конструкторы

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
    }
}