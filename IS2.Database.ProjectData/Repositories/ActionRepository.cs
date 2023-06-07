﻿using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ProjectData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы с действиями
    /// </summary>
    public class ActionRepository : IVersioningRepository<ActionEntity, Guid>
    {
        private readonly ProjectDataContext _context;

        public ActionRepository(ProjectDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionEntity Add(ActionEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.Actions.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.Actions
                .Where(s => s.ActionId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.Actions
                .Where(s => s.ActionId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}