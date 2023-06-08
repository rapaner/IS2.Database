using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы со статусами моделей
    /// </summary>
    public interface IModelStatusRepository : IVersioningRepository<ModelStatusEntity, Guid>
    {
    }
}