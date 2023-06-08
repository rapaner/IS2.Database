using IS2.Database.Common.Repositories;
using IS2.Database.ConfigurationData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS2.Database.ConfigurationData.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий настроек
    /// </summary>
    public interface ISettingRepository : IVersioningRepository<SettingEntity, Guid>
    {
    }
}
