using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с задачами
    /// </summary>
    public interface ITaskRepository : IVersioningRepository<TaskEntity, Guid>
    {
    }
}