﻿using IS2.Database.Common.Contexts;
using IS2.Database.ProjectData.Model;
using IS2.Database.ProjectData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ProjectData.Repositories
{
    /// <summary>
    /// Репозиторий работы со связями между действиями
    /// </summary>
    public class ActionLinkRepository : IActionLinkRepository
    {
        private readonly ProjectDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public ActionLinkRepository(ProjectDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public ActionLinkEntity Add(ActionLinkEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.ActionLinks.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ActionLinkEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.ActionLinks
                .Where(s => s.ActionLinkId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<ActionLinkEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.ActionLinks
                .Where(s => s.ActionLinkId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}