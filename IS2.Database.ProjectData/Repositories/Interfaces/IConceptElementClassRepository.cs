using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;

namespace IS2.Database.ProjectData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с классами элемента концептуальной структуры
    /// </summary>
    public interface IConceptElementClassRepository : IVersioningRepository<ConceptElementClassEntity, short>
    {
    }
}