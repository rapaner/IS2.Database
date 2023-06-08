using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;

namespace IS2.Database.ManagementData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий работы с пользователями
    /// </summary>
    public interface IUserRepository : IVersioningRepository<UserEntity, Guid>
    {
    }
}