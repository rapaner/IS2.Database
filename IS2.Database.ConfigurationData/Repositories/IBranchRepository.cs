using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий работы с ветками
    /// </summary>
    public interface IBranchRepository
    {
        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<BranchEntity> FindById(Guid branchId);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BranchEntity Add(BranchEntity branch);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="branchEntity"></param>
        /// <returns></returns>
        BranchEntity Update(BranchEntity branch);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="branchEntity"></param>
        /// <returns></returns>
        BranchEntity Delete(BranchEntity branch);
    }
}
