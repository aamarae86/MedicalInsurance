using AutoMapper;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__Warehouses._IvPriceListHd.Dto;
using ERP.Helpers.Core;
using ERP._System.__Warehouses._IvItems.Dto;
using ERP._System.__Warehouses._IvItems;

namespace ERP._System.__Warehouses._IvWarehouseItems
{
    public class IvWarehouseItemsMapperProfile : Profile
    {
        public IvWarehouseItemsMapperProfile()
        {
            // CreateMap<IvWarehouseItems, IvWarehouseItemsDto>()
            //   .ReverseMap();

            // CreateMap<IvItemsDto, IvItems>()
            //.ForMember(dest => dest.IvWarehouseItems , source => source.MapFrom(o => o.IvWarehouseItems))
            //     .ReverseMap();

         //   CreateMap<IvItems, IvItemsDto>()
         //.ForMember(dest => dest.CurrentOnHand, source => source.MapFrom(o => o.IvWarehouseItems))
         //       .ReverseMap();
        }
    }
}
