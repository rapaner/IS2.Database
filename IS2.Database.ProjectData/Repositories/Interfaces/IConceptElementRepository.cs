using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с элементами концептуальной структуры
    /// </summary>
    public interface IConceptElementRepository : IVersioningRepository<ConceptElementEntity, Guid>
    {
    }
}