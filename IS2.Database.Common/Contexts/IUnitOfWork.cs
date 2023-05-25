﻿namespace IS2.Database.Common.Contexts
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Сохранение данных в БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохранение данных в БД с диспетчеризацией доменных событий
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}