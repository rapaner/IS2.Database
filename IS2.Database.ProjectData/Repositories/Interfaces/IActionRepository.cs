using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с действиями
    /// </summary>
    public interface IActionRepository : IVersioningRepository<ActionEntity, Guid>
    {
    }
}