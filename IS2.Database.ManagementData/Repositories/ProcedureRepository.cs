﻿using IS2.Database.Common.Contexts;
using IS2.Database.ManagementData.Model;
using IS2.Database.ManagementData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с процедурами
    /// </summary>
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly ManagementDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ProcedureRepository(ManagementDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ProcedureEntity Add(ProcedureEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Procedures.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProcedureEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Procedures
                .Where(s => s.ProcedureId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ProcedureEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Procedures
                .Where(s => s.ProcedureId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}