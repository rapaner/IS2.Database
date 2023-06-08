using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы со взаимосвязями процедур и модулей
    /// </summary>
    public interface IProcedureToModuleRepository : IVersioningRepository<ProcedureToModuleEntity, Guid>
    {
    }
}