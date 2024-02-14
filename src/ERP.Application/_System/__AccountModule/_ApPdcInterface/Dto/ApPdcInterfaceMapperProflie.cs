using AutoMapper;
using ERP._System._ApPdcInterface;
using ERP._System._ApPdcInterface.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ApPdcInterface.Dto
{
    public class ApPdcInterfaceMapperProflie : Profile
    {
        public ApPdcInterfaceMapperProflie()
        {
            CreateMap<ApPdcInterface, ApPdcInterfaceDto>()
               .ForMember(dest => dest.ReversedDate, source => source.MapFrom(o => o.ReversedDate.HasValue ? o.ReversedDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               .ForMember(dest => dest.ConfirmedDate, source => source.MapFrom(o => o.ConfirmedDate.HasValue ? o.ConfirmedDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.HasValue ? o.MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               ;
        }
    }
}
