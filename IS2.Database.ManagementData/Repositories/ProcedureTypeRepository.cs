using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с типами процедур
    /// </summary>
    public class ProcedureTypeRepository : IVersioningRepository<ProcedureTypeEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ProcedureTypeRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ProcedureTypeEntity Add(ProcedureTypeEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ProcedureTypes.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProcedureTypeEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ProcedureTypes
                .Where(s => s.ProcedureTypeId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ProcedureTypeEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ProcedureTypes
                .Where(s => s.ProcedureTypeId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}