using IS2.Database.Common.Model;

namespace IS2.Database.ManagementData.Model
{
    /// <summary>
    /// Проект
    /// </summary>
    public class ProjectEntity : VersioningEntity
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="name">Название</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public ProjectEntity(Guid projectId, string name, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId) : base(versionId)
        {
            ProjectId = projectId;
            Name = name;
            StatusId = statusId;
            DateStartPlan = dateStartPlan;
            DateFinishPlan = dateFinishPlan;
            DateStartFact = dateStartFact;
            DateFinishFact = dateFinishFact;
        }

        #endregion Конструкторы

        #region Методы

        /// <summary>
        /// Новый объект
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="statusId">Код статуса</param>
        /// <param name="dateStartPlan">Плановый срок начала</param>
        /// <param name="dateFinishPlan">Плановый срок окончания</param>
        /// <param name="dateStartFact">Фактический срок начала</param>
        /// <param name="dateFinishFact">Фактический срок окончания</param>
        /// <param name="versionId">Идентификатор версии</param>
        public static ProjectEntity New(string name, short statusId, DateTime dateStartPlan, DateTime dateFinishPlan, DateTime? dateStartFact, DateTime? dateFinishFact, Guid versionId)
        {
            return new ProjectEntity(default, name, statusId, dateStartPlan, dateFinishPlan, dateStartFact, dateFinishFact, versionId);
        }

        /// <summary>
        /// Новый объект с другим идентификатором версии
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="versionId">Новая версия</param>
        public static ProjectEntity NewFromExisting(ProjectEntity entity, Guid versionId)
        {
            var newEntity = new ProjectEntity(entity.ProjectId, entity.Name, entity.StatusId, entity.DateStartPlan, entity.DateFinishPlan, entity.DateStartFact, entity.DateFinishFact, versionId);
            return newEntity;
        }

        #endregion Методы

        #region Свойства

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Guid ProjectId { get; protected set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Код статуса
        /// </summary>
        public short StatusId { get; protected set; }

        /// <summary>
        /// Плановый срок начала
        /// </summary>
        public DateTime DateStartPlan { get; protected set; }

        /// <summary>
        /// Плановый срок окончания
        /// </summary>
        public DateTime DateFinishPlan { get; protected set; }

        /// <summary>
        /// Фактический срок начала
        /// </summary>
        public DateTime? DateStartFact { get; protected set; }

        /// <summary>
        /// Фактический срок окончания
        /// </summary>
        public DateTime? DateFinishFact { get; protected set; }

        #endregion Свойства
    }
}