using AutoMapper;
using ERP._System._GlPeriods;
using ERP._System._GlPeriods.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._GlPeriods.GlPeriodYears.Dto
{
    public class GlPeriodsMapperProfile : Profile
    {
        public GlPeriodsMapperProfile()
        {
            CreateMap<GlPeriodsYears, GlPeriodsYearsDto>()
              .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateGlPeriodsYearsDto, GlPeriodsYears>()
              .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
              .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)));

            CreateMap<GlPeriodsYearsEditDto, GlPeriodsYears>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)));
        }
    }
}
