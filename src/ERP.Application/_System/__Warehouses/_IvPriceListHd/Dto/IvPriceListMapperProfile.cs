using AutoMapper;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__Warehouses._IvPriceListHd.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    public class IvPriceListMapperProfile : Profile
    {
        public IvPriceListMapperProfile()
        {

            CreateMap<IvPriceListTr, IvPriceListTrDto>()
              .ForPath(dest => dest.ItemName, source => source.MapFrom(o => o.IvItems.ItemName))
              .ReverseMap();

        }
    }
}