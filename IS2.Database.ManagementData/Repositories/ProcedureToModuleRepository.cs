using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using IS2.Database.ManagementData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы со взаимосвязями процедур и модулей
    /// </summary>
    public class ProcedureToModuleRepository : IProcedureToModuleRepository
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ProcedureToModuleRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ProcedureToModuleEntity Add(ProcedureToModuleEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ProcedureToModules.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProcedureToModuleEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ProcedureToModules
                .Where(s => s.ProcedureToModuleId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ProcedureToModuleEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ProcedureToModules
                .Where(s => s.ProcedureToModuleId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}