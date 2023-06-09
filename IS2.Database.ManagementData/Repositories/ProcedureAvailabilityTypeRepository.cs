﻿using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using IS2.Database.ManagementData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с типами доступности процедур
    /// </summary>
    public class ProcedureAvailabilityTypeRepository : IProcedureAvailabilityTypeRepository
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ProcedureAvailabilityTypeRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ProcedureAvailabilityTypeEntity Add(ProcedureAvailabilityTypeEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ProcedureAvailabilityTypes.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProcedureAvailabilityTypeEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ProcedureAvailabilityTypes
                .Where(s => s.ProcedureAvailabilityTypeId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ProcedureAvailabilityTypeEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ProcedureAvailabilityTypes
                .Where(s => s.ProcedureAvailabilityTypeId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}