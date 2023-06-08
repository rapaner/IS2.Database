using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий работы с ветками
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Объект для сохранения данных
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="branchId">Идентификатор ветви</param>
        Task<BranchEntity> FindById(Guid branchId);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="branch">Ветвь</param>
        BranchEntity Add(BranchEntity branch);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="branch">Ветвь</param>
        BranchEntity Update(BranchEntity branch);
    }
}