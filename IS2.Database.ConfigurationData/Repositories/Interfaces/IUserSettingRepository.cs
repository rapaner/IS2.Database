using IS2.Database.Common.Repositories;
using IS2.Database.ConfigurationData.Model;

namespace IS2.Database.ConfigurationData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий настроек пользователей
    /// </summary>
    public interface IUserSettingRepository : IVersioningRepository<UserSettingEntity, Guid>
    {
    }
}