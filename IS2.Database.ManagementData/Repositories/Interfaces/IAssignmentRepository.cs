using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий назначений
    /// </summary>
    public interface IAssignmentRepository : IVersioningRepository<AssignmentEntity, Guid>
    {
    }
}