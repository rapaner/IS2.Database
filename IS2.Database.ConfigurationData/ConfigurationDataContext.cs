using IS2.Database.Common.Contexts;
using IS2.Database.Common.Model;
using IS2.Database.ConfigurationData.EntityConfiguration;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ConfigurationData
{
    /// <summary>
    /// Контекст конфигурационного блока
    /// </summary>
    public partial class ConfigurationDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// Ветви
        /// </summary>
        public virtual DbSet<BranchEntity> Branches { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public virtual DbSet<SettingEntity> Settings { get; set; }

        /// <summary>
        /// Настройки пользователей
        /// </summary>
        public virtual DbSet<UserSettingEntity> UserSettings { get; set; }

        /// <summary>
        /// Версии
        /// </summary>
        public virtual DbSet<VersionEntity> Versions { get; set; }

        /// <summary>
        /// Типы версий
        /// </summary>
        public virtual DbSet<VersionTypeEntity> VersionTypes { get; set; }

        /// <summary>
        /// Получить текущую транзакцию
        /// </summary>
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        /// <summary>
        /// Есть активная транзакция?
        /// </summary>
        public bool HasActiveTransaction => _currentTransaction != null;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">Настройки</param>
        public ConfigurationDataContext(DbContextOptions<ConfigurationDataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="modelBuilder">Строитель модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new UserSettingConfiguration());
            modelBuilder.ApplyConfiguration(new VersionConfiguration());
            modelBuilder.ApplyConfiguration(new VersionTypeConfiguration());

            modelBuilder.Entity<VersionTypeEntity>().HasData(Enumeration.GetAll<VersionTypeEntity>());
        }

        /// <inheritdoc/>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            _ = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// Начало транзакции
        /// </summary>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        /// <summary>
        /// Сохранение транзакции
        /// </summary>
        /// <param name="transaction">Транзакция</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction)
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// Откат транзакции
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}