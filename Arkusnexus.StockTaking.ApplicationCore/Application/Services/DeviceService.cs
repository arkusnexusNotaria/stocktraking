using Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Arkusnexus.StockTaking.ApplicationCore.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;
        private readonly IGenericRepository<Device> _genericRepositoryDevice;

        private readonly ILogger _logger;

        public DeviceService(IDeviceRepository repository,
            IGenericRepository<Device> genericRepositoryDevice,
            ILogger<DeviceService> logger)
        {
            _repository = repository;
            _genericRepositoryDevice = genericRepositoryDevice;
            _logger = logger;

        }
        public async Task<Device> AddAsync(Device Entity)
        {
            try
            {
                var result = await _genericRepositoryDevice.AddAsync(Entity);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public void Delete(Device entity)
        {
            try
            {
                _genericRepositoryDevice.Delete(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            try
            {
                return await _genericRepositoryDevice.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<Device> GetByIdAsync(int id)
        {
            try
            {
                return await _genericRepositoryDevice.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<Device> UpdateDevice(Device device)
        {
            try
            {
                return await _repository.UpdateDevice(device);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
