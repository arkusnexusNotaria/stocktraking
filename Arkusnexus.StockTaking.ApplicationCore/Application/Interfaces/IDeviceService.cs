using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;

namespace Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces
{
    public interface IDeviceService : IGenericService<Device>
    {
        Task<Device> UpdateDevice(Device device);
    }
}
