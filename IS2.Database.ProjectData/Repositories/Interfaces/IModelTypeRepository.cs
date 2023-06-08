using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с типами моделей
    /// </summary>
    public interface IModelTypeRepository : IVersioningRepository<ModelTypeEntity, Guid>
    {
    }
}