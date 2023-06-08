using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с типами действий
    /// </summary>
    public interface IActionTypeRepository : IVersioningRepository<ActionTypeEntity, short>
    {
    }
}