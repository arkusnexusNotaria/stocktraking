using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Arkusnexus.StockTaking.Infrastructure.Repositories
{
    public class DeviceItemRepository : IDeviceItemRepository
    {
        private readonly StockTakingDbContext _context;
        private readonly ILogger _logger;

        public DeviceItemRepository(StockTakingDbContext context, ILogger<DeviceItemRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<DeviceItem>> GetByFilters(int? DeviceId, string? SerialNumber, string? Brand, string? Model, int? Status)
        {
            try
            {
                var query = _context.DeviceItems.AsQueryable();

                if(DeviceId.HasValue)
                    query = query.Where(x => x.DeviceId == DeviceId);
                
                if (!string.IsNullOrWhiteSpace(SerialNumber))                 
                    query = query.Where(x => x.SerialNumber.Trim().ToLower() ==  SerialNumber.ToLower().Trim());

                if(!string.IsNullOrWhiteSpace(Brand))
                    query = query.Where(x => x.Brand.Trim().ToLower() ==  Brand.Trim().ToLower());

                if(!string.IsNullOrWhiteSpace(Model))
                    query = query.Where(x => x.Model.Trim().ToLower() == Model.Trim().ToLower());

                if(Status.HasValue)
                    query = query.Where(x => x.Status ==  Status);

                return await query.ToListAsync();               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public async Task<IEnumerable<DeviceItem>> GetByStatus(int Status)
        {
            try
            {
                return await _context.DeviceItems
                    .Where(x => x.Status == Status).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public async Task<DeviceItem> UpdateDeviceItem(DeviceItem deviceitem)
        {
            try
            {
                var currentEntity = await _context.DeviceItems.FindAsync(deviceitem.Id);
                currentEntity.ModifiedDate = DateTime.Now;
                currentEntity.DeviceId = deviceitem.DeviceId;
                currentEntity.SerialNumber = deviceitem.SerialNumber;
                currentEntity.Brand = deviceitem.Brand;
                currentEntity.Model = deviceitem.Model;
                currentEntity.Notes = deviceitem.Notes;
                currentEntity.Comments = deviceitem.Comments;
                currentEntity.Status = deviceitem.Status;
                await _context.SaveChangesAsync();
                return currentEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}