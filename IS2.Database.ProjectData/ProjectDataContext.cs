using IS2.Database.Common.Contexts;
using IS2.Database.ProjectData.EntityConfiguration;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace IS2.Database.ProjectData
{
    /// <summary>
    /// Контекст проектного блока
    /// </summary>
    public partial class ProjectDataContext : DbContext, IUnitOfWork
    {
        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// Действия
        /// </summary>
        public virtual DbSet<ActionEntity> Actions { get; set; }

        /// <summary>
        /// Степени формализации действий
        /// </summary>
        public virtual DbSet<ActionFormalizationEntity> ActionFormalizations { get; set; }

        /// <summary>
        /// Связи между действиями
        /// </summary>
        public virtual DbSet<ActionLinkEntity> ActionLinks { get; set; }

        /// <summary>
        /// Типы связей
        /// </summary>
        public virtual DbSet<ActionLinkTypeEntity> ActionLinkTypes { get; set; }

        /// <summary>
        /// Статусы действий
        /// </summary>
        public virtual DbSet<ActionStatusEntity> ActionStatuses { get; set; }

        /// <summary>
        /// Типы действий
        /// </summary>
        public virtual DbSet<ActionTypeEntity> ActionTypes { get; set; }

        /// <summary>
        /// Элементы концептуальной структуры
        /// </summary>
        public virtual DbSet<ConceptElementEntity> ConceptElements { get; set; }

        /// <summary>
        /// Классы концептуальной структуры
        /// </summary>
        public virtual DbSet<ConceptElementClassEntity> ConceptElementClasses { get; set; }

        /// <summary>
        /// Группы концептуальной структуры
        /// </summary>
        public virtual DbSet<ConceptElementGroupEntity> ConceptElementGroups { get; set; }

        /// <summary>
        /// Модели
        /// </summary>
        public virtual DbSet<ModelEntity> Models { get; set; }

        /// <summary>
        /// Статусы моделей
        /// </summary>
        public virtual DbSet<ModelStatusEntity> ModelStatuses { get; set; }

        /// <summary>
        /// Типы моделей
        /// </summary>
        public virtual DbSet<ModelTypeEntity> ModelTypes { get; set; }

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
        public ProjectDataContext(DbContextOptions<ProjectDataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="modelBuilder">Строитель модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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