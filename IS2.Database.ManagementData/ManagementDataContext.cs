using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.EntityConfiguration;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ManagementData
{
    /// <summary>
    /// Контекст управленческого блока
    /// </summary>
    public partial class ManagementDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// Назначения
        /// </summary>
        public virtual DbSet<AssignmentEntity> Assignments { get; set; }

        /// <summary>
        /// Процедуры
        /// </summary>
        public virtual DbSet<ProcedureEntity> Procedures { get; set; }

        /// <summary>
        /// Типы доступности процедур
        /// </summary>
        public virtual DbSet<ProcedureAvailabilityTypeEntity> ProcedureAvailabilityTypes { get; set; }

        /// <summary>
        /// Взаимосвязи процедур и модулей
        /// </summary>
        public virtual DbSet<ProcedureToModuleEntity> ProcedureToModules { get; set; }

        /// <summary>
        /// Типы процедур
        /// </summary>
        public virtual DbSet<ProcedureTypeEntity> ProcedureTypes { get; set; }

        /// <summary>
        /// Проекты
        /// </summary>
        public virtual DbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// Роли
        /// </summary>
        public virtual DbSet<RoleEntity> Roles { get; set; }

        /// <summary>
        /// Сессии
        /// </summary>
        public virtual DbSet<SessionEntity> Sessions { get; set; }

        /// <summary>
        /// Наборы шаблонов спецификаций
        /// </summary>
        public virtual DbSet<SpecificationTemplatePackageEntity> SpecificationTemplatePackages { get; set; }

        /// <summary>
        /// Этапы
        /// </summary>
        public virtual DbSet<StageEntity> Stages { get; set; }

        /// <summary>
        /// Типы этапов
        /// </summary>
        public virtual DbSet<StageTypeEntity> StageTypes { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public virtual DbSet<TaskEntity> Tasks { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public virtual DbSet<UserEntity> Users { get; set; }

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
        public ManagementDataContext(DbContextOptions<ManagementDataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="modelBuilder">Строитель модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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