using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
namespace Arkusnexus.StockTaking.ApplicationCore.Core.Interfaces
{
    public interface IDeviceItemRepository
    {
        Task<DeviceItem> UpdateDeviceItem(DeviceItem deviceitem);

        Task<IEnumerable<DeviceItem>> GetByStatus(int Status);

        Task<IEnumerable<DeviceItem>> GetByFilters(int? DeviceId, string? SerialNumber, string? Brand, string? Model, int? Status);
    }
}