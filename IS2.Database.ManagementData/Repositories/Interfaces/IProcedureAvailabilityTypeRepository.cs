using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с типами доступности процедур
    /// </summary>
    public interface IProcedureAvailabilityTypeRepository : IVersioningRepository<ProcedureAvailabilityTypeEntity, Guid>
    {
    }
}