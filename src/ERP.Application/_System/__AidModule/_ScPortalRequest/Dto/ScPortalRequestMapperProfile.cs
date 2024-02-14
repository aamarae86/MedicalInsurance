using AutoMapper;
using ERP._System.__AidModule._ScPortalRequestVisited;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    public class ScPortalRequestMapperProfile : Profile
    {
        public ScPortalRequestMapperProfile()
        {
            CreateMap<ScPortalRequest, ScPortalRequestDto>()
                .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.PortalRequestDate, source => source.MapFrom(o => o.PortalRequestDate.ToString(Formatters.DateFormat)));

            CreateMap<ScPortalRequestCreateDto, ScPortalRequest>()
                .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
                .ForMember(dest => dest.PortalRequestDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PortalRequestDate)));

            CreateMap<ScPortalRequestEditDto, ScPortalRequest>()
                .ForMember(dest => dest.PortalRequestDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PortalRequestDate)));

            CreateMap<ScPortalRequestVisitedDto, ScPortalRequestVisited>()
              .ForMember(dest => dest.VisitDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{o.visitDate} {o.visitTime}")));

            CreateMap<ScPortalRequestVisited, ScPortalRequestVisitedDto>()
              .ForMember(dest => dest.visitDate, source => source.MapFrom(o => o.VisitDate.ToString(Formatters.DateTimeFormat_AM_PM)));
        }
    }
}
