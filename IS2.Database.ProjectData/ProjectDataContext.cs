using IS2.Database.Common.Contexts;
using IS2.Database.ProjectData.EntityConfiguration;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ProjectData
{
    public partial class ProjectDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        public virtual DbSet<ActionEntity> Actions { get; set; }
        public virtual DbSet<ActionFormalizationEntity> ActionFormalizations { get; set; }
        public virtual DbSet<ActionLinkEntity> ActionLinks { get; set; }
        public virtual DbSet<ActionLinkTypeEntity>  ActionLinkTypes { get; set; }
        public virtual DbSet<ActionStatusEntity>  ActionStatuses{ get; set; }
        public virtual DbSet<ActionTypeEntity>  ActionTypes { get; set; }
        public virtual DbSet<ConceptElementEntity>  ConceptElements { get; set; }
        public virtual DbSet<ConceptElementClassEntity> ConceptElementClasses { get; set; }
        public virtual DbSet<ConceptElementGroupEntity> ConceptElementGroups { get; set; }
        public virtual DbSet<ModelEntity> Models { get; set; }
        public virtual DbSet<ModelStatusEntity> ModelStatuses{ get; set; }
        public virtual DbSet<ModelTypeEntity> ModelTypes{ get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public ProjectDataContext(DbContextOptions<ProjectDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.ApplyConfiguration(new ActionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionFormalizationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionLinkEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionLinkTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ActionTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptElementClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptElementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptElementGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModelStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModelTypeEntityConfiguration());
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