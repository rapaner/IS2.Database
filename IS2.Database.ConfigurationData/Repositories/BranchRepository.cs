﻿using IS2.Database.Common.Contexts;
using IS2.Database.ConfigurationData.Model;
using IS2.Database.ConfigurationData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IS2.Database.ConfigurationData.Repositories
{
    /// <summary>
    /// Репозиторий работы с ветками
    /// </summary>
    public class BranchRepository : IBranchRepository
    {
        private readonly ConfigurationDataContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public BranchRepository(ConfigurationDataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IUnitOfWork UnitOfWork => _context;

        /// <inheritdoc/>
        public BranchEntity Add(BranchEntity branch)
        {
            if (branch.IsTransient())
            {
                return _context.Branches.Add(branch).Entity;
            }

            return branch;
        }

        /// <inheritdoc/>
        public BranchEntity Delete(BranchEntity branch)
        {
            branch.SetIsDeleted();
            return _context.Branches.Update(branch).Entity;
        }

        /// <inheritdoc/>
        public async Task<BranchEntity> FindById(Guid branchId)
        {
            var branch = await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == branchId);
            return branch;
        }

        /// <inheritdoc/>
        public BranchEntity Update(BranchEntity branch)
        {
            return _context.Branches.Update(branch).Entity;
        }
    }
}