using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    public class Assignment : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="assignmentId">Идентификатор назначения</param>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        /// <param name="dateInsert">Дата вставки записи</param>
        /// <param name="isDeleted">Удалена?</param>
        public Assignment(Guid id, Guid assignmentId, Guid procedureId, Guid roleId, Guid userId, DateTime dateStart, DateTime? dateFinish, Guid versionId, DateTime dateInsert, bool isDeleted) : base(id, versionId, dateInsert, isDeleted)
        {
            AssignmentId = assignmentId;
            ProcedureId = procedureId;
            RoleId = roleId;
            UserId = userId;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }

        #endregion Конструкторы

        #region Свойства

        /// <summary>
        /// Идентификатор назначения
        /// </summary>
        public Guid AssignmentId { get; protected set; }

        /// <summary>
        /// Идентификатор процедуры
        /// </summary>
        public Guid ProcedureId { get; protected set; }

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        public Guid RoleId { get; protected set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; protected set; }

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