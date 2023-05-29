using IS2.Database.Common.Contexts;
using IS2.Database.Common.Model;
using IS2.Database.ConfigurationData.EntityConfiguration;
using IS2.Database.ConfigurationData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ConfigurationData
{
    public partial class ConfigurationDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        public virtual DbSet<BranchEntity> Branches { get; set; }
        public virtual DbSet<SettingEntity> Settings { get; set; }
        public virtual DbSet<UserSettingEntity> UserSettings { get; set; }
        public virtual DbSet<Model.VersionEntity> Versions { get; set; }
        public virtual DbSet<VersionTypeEntity> VersionTypes { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public ConfigurationDataContext(DbContextOptions<ConfigurationDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());
            modelBuilder.ApplyConfiguration(new UserSettingConfiguration());
            modelBuilder.ApplyConfiguration(new VersionConfiguration());
            modelBuilder.ApplyConfiguration(new VersionTypeConfiguration());

            modelBuilder.Entity<VersionTypeEntity>().HasData(Enumeration.GetAll<VersionTypeEntity>());
        }

        /// <summary>
        /// Сохранение сущностей в бд. Метод должен вызваться из логики приложения
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            _ = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

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