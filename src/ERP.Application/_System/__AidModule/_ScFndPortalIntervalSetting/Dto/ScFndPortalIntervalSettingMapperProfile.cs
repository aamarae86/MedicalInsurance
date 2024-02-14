using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto
{
    public class ScFndPortalIntervalSettingMapperProfile : Profile
    {
        public ScFndPortalIntervalSettingMapperProfile()
        {
            CreateMap<ScFndPortalIntervalSetting, ScFndPortalIntervalSettingDto>()
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => o.FromDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.FromTime, source => source.MapFrom(o => o.FromDate.ToString(Formatters.TimeFormat_AM_PM)))
              .ForMember(dest => dest.ToTime, source => source.MapFrom(o => o.ToDate.ToString(Formatters.TimeFormat_AM_PM)))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => o.ToDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateScFndPortalIntervalSettingDto, ScFndPortalIntervalSetting>()
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{o.FromDate} {o.FromTime}")))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{o.ToDate} {o.ToTime}")));

            CreateMap<ScFndPortalIntervalSettingEditDto, ScFndPortalIntervalSetting>()
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{o.FromDate} {o.FromTime}")))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{o.ToDate} {o.ToTime}")));
        }
    }
}
