using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.EntityConfiguration;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ManagementData
{
    public partial class ManagementDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        public virtual DbSet<AssignmentEntity> Assignments { get; set; }
        public virtual DbSet<ProcedureEntity> Procedures { get; set; }
        public virtual DbSet<ProcedureAvailabilityTypeEntity> ProcedureAvailabilityTypes { get; set; }
        public virtual DbSet<ProcedureToModuleEntity> ProcedureToModules { get; set; }
        public virtual DbSet<ProcedureTypeEntity> ProcedureTypes { get; set; }
        public virtual DbSet<ProjectEntity> Projects { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<SessionEntity> Sessions { get; set; }
        public virtual DbSet<SpecificationTemplatePackageEntity> SpecificationTemplatePackages { get; set; }
        public virtual DbSet<StageEntity> Stages { get; set; }
        public virtual DbSet<StageTypeEntity> StageTypes { get; set; }
        public virtual DbSet<TaskEntity> Tasks { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public ManagementDataContext(DbContextOptions<ManagementDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureAvailabilityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureToModuleConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificationTemplatePackageConfiguration());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new StageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
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