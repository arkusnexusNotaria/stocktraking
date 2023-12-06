using Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Arkusnexus.StockTaking.ApplicationCore.Application.Services
{
    public class DeviceItemService : IDeviceItemService
    {
        private readonly IDeviceItemRepository _repository;
        private readonly IGenericRepository<DeviceItem> _genericRepositoryDeviceItem;

        private readonly ILogger _logger;

        public DeviceItemService(IDeviceItemRepository repository,
            IGenericRepository<DeviceItem> genericRepositoryDeviceItem,
            ILogger<DeviceItemService> logger)
        {
            _repository = repository;
            _genericRepositoryDeviceItem = genericRepositoryDeviceItem;
            _logger = logger;

        }
        public async Task<DeviceItem> AddAsync(DeviceItem Entity)
        {
            try
            {
                var result = await _genericRepositoryDeviceItem.AddAsync(Entity);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<DeviceItem> ChangeStatus(int DeviceItemId, int Status)
        {
            try
            {
               var currentItem =   await _genericRepositoryDeviceItem.GetByIdAsync(DeviceItemId);
                currentItem.Status = Status;
                await _repository.UpdateDeviceItem(currentItem);
                return currentItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public void Delete(DeviceItem entity)
        {
            try
            {
                _genericRepositoryDeviceItem.Delete(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<DeviceItem>> GetAllAsync()
        {
            try
            {
                return await _genericRepositoryDeviceItem.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<DeviceItem>> GetByFilters(int? DeviceId, string? SerialNumber, string? Brand, string? Model, int? Status)
        {
            try
            {
                return await _repository.GetByFilters(DeviceId,SerialNumber,Brand,Model,Status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<DeviceItem> GetByIdAsync(int id)
        {
            try
            {
                return await _genericRepositoryDeviceItem.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<DeviceItem>> GetByStatusAsync(int Status)
        {
            try
            {
                return await _repository.GetByStatus(Status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<DeviceItem> UpdateDeviceItem(DeviceItem deviceitem)
        {
            try
            {
                return await _repository.UpdateDeviceItem(deviceitem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
