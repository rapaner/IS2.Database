using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Назначение
    /// </summary>
    public class AssignmentEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="assignmentId">Идентификатор назначения</param>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        protected AssignmentEntity(Guid assignmentId, Guid procedureId, Guid roleId, Guid userId, DateTime dateStart, DateTime? dateFinish, Guid versionId) : base(versionId)
        {
            AssignmentId = assignmentId;
            ProcedureId = procedureId;
            RoleId = roleId;
            UserId = userId;
            DateStart = dateStart;
            DateFinish = dateFinish;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="procedureId">Идентификатор процедуры</param>
        /// <param name="roleId">Идентификатор роли</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="dateStart">Дата начала</param>
        /// <param name="dateFinish">Дата окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static AssignmentEntity New(Guid procedureId, Guid roleId, Guid userId, DateTime dateStart, DateTime? dateFinish, Guid versionId)
        {
            return new AssignmentEntity(default, procedureId, roleId, userId, dateStart, dateFinish, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static AssignmentEntity NewFromExisting(AssignmentEntity entity, Guid versionId)
        {
            var newEntity = new AssignmentEntity(entity.AssignmentId, entity.ProcedureId, entity.RoleId, entity.UserId, entity.DateStart, entity.DateFinish, versionId);
            return newEntity;
        }

        #endregion Методы

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