using IS2.Database.Common.Contexts;
using IS2.Database.Common.Repositories;
using IS2.Database.ManagementData.Model;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ManagementData.Repositories
{
    /// <summary>
    /// Репозиторий работы с наборами шаблонов спецификаций
    /// </summary>
    public class SpecificationTemplatePackageRepository : IVersioningRepository<SpecificationTemplatePackageEntity, Guid>
    {
        private readonly ManagementDataContext _context;

        public SpecificationTemplatePackageRepository(ManagementDataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public SpecificationTemplatePackageEntity Add(SpecificationTemplatePackageEntity entity)
        {
            if (entity.IsTransient())
            {
                return _context.SpecificationTemplatePackages.Add(entity).Entity;
            }

            return entity;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SpecificationTemplatePackageEntity>> FindAllVersionsById(Guid entityId, IEnumerable<Guid> versionIds)
        {
            var settings = await _context.SpecificationTemplatePackages
                .Where(s => s.SpecificationTemplatePackageId == entityId && versionIds.Contains(s.VersionId))
                .ToListAsync();
            return settings;
        }

        /// <inheritdoc/>
        public async Task<SpecificationTemplatePackageEntity> FindByIdAndVersionId(Guid entityId, Guid versionId)
        {
            var setting = await _context.SpecificationTemplatePackages
                .Where(s => s.SpecificationTemplatePackageId == entityId && s.VersionId == versionId)
                .FirstOrDefaultAsync();
            return setting;
        }
    }
}