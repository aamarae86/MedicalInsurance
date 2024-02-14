using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    public class IvReceiveHdMapperProfile : Profile
    {
        public IvReceiveHdMapperProfile()
        {

            CreateMap<IvReceiveHd, IvReceiveHdDto>()
              .ForMember(dest => dest.HdReceiveDate, source => source.MapFrom(o => o.HdReceiveDate.ToString(Formatters.DateFormat)));

            CreateMap<IvReceiveHdCreateDto, IvReceiveHd>()
               .ForMember(dest => dest.HdReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdReceiveDate)));

            CreateMap<IvReceiveHdEditDto, IvReceiveHd>()
               .ForMember(dest => dest.HdReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdReceiveDate)));
        }
    }
}
