using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Arkusnexus.StockTaking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkusnexus.StockTaking.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StockTakingDbContext _context;
        private readonly ILogger _logger;
        public GenericRepository(StockTakingDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<T> AddAsync(T Entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(Entity);
                await _context.SaveChangesAsync();
                return Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
