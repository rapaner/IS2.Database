using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы со связями между действиями
    /// </summary>
    public interface IActionLinkRepository : IVersioningRepository<ActionLinkEntity, Guid>
    {
    }
}