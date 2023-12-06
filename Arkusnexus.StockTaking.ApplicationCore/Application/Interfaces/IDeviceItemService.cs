using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;

namespace Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces
{
    public interface IDeviceItemService : IGenericService<DeviceItem>
    {
        Task<DeviceItem> UpdateDeviceItem(DeviceItem deviceitem);

        Task<DeviceItem> ChangeStatus(int DeviceItemId, int Status);

        Task<IEnumerable<DeviceItem>> GetByStatusAsync(int Status);

        Task<IEnumerable<DeviceItem>> GetByFilters(int? DeviceId, string? SerialNumber, string? Brand, string? Model, int? Status);
    }
}
