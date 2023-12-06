//using Arkusnexus.StockTaking.API.Dtos;
using Arkusnexus.StockTaking.API.Dtos;
using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using AutoMapper;

namespace Arkusnexus.StockTaking.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceDto, Device>();

            CreateMap<DeviceItem, DeviceItemDto>();
            CreateMap<DeviceItemDto, DeviceItem>();
        }
    }
}
