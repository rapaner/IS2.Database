namespace IS2.Database.Common.Contexts
{
    /// <summary>
    /// Интерфейс для сохранения данных
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохранение данных в БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}