using AutoMapper;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
    public class IvInventorySettingMapperProfile : Profile
    {
        public IvInventorySettingMapperProfile()
        {

            CreateMap<IvInventorySettingPriceListDto, IvInventorySettingPriceList>()
              .ReverseMap();
            CreateMap<IvInventorySettingPriceList, IvInventorySettingPriceListDto>()
              .ForPath(dest => dest.PriceListName, source => source.MapFrom(o => o.IvPriceListHd.PriceListName))
              .ReverseMap();
            CreateMap<IvInventorySetting, IvInventorySettingDto>()
             .ForPath(dest => dest.UserId, source => source.MapFrom(o => o.User.Id))
             .ReverseMap();

            CreateMap<IvInventorySetting, IvInventorySettingDto>()
               .ForPath(dest => dest.UserName, source => source.MapFrom(o => o.User.UserName))
           .ReverseMap();

            CreateMap<IvInventorySettingEditDto, IvInventorySetting>()
           .ReverseMap();
            CreateMap<IvUserWarehousesPrivilegesExtDto, IvUserWarehousesPrivileges>()
          .ReverseMap();

            CreateMap<IvUserWarehousesPrivileges, IvUserWarehousesPrivilegesExtDto>()
               .ForMember(dest => dest.warehouseName, source => source.MapFrom(o => o.IvWarehouses.WarehouseName))
           .ReverseMap()
            .ForMember(x => x.IvWarehouses, opt => opt.Ignore());


        }
    }
}