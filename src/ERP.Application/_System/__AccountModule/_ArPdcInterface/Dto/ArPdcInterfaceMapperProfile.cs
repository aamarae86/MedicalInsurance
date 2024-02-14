using AutoMapper;
using ERP._System._ArPdcInterface;
using ERP._System._ArPdcInterface.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArPdcInterface.Dto
{
    public class ArPdcInterfaceMapperProfile : Profile
    {
        public ArPdcInterfaceMapperProfile()
        {
            CreateMap<ArPdcInterface, ArPdcInterfaceDto>()
               .ForMember(dest => dest.ReversedDate, source => source.MapFrom(o => o.ReversedDate.HasValue ? o.ReversedDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               .ForMember(dest => dest.ConfirmedDate, source => source.MapFrom(o => o.ConfirmedDate.HasValue ? o.ConfirmedDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.HasValue ? o.MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               ;

            CreateMap<ArPdcInterfaceEditDto, ArPdcInterface>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)));
        }
    }
}
