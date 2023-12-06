using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Arkusnexus.StockTaking.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly StockTakingDbContext _context;
        private readonly ILogger _logger;

        public DeviceRepository(StockTakingDbContext context, ILogger<DeviceRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<Device> UpdateDevice(Device device)
        {
            try
            {
                var currentEntity = await _context.Devices.FindAsync(device.Id);
                currentEntity.ModifiedDate = DateTime.Now;
                currentEntity.Description = device.Description;
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