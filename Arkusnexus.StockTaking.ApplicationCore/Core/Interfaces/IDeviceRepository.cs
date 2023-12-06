using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
namespace Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> UpdateDevice(Device device);
    }
}