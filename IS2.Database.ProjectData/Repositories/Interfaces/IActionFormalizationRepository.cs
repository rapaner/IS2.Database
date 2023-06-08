using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы со степенями формализации действий
    /// </summary>
    public interface IActionFormalizationRepository : IVersioningRepository<ActionFormalizationEntity, short>
    {
    }
}