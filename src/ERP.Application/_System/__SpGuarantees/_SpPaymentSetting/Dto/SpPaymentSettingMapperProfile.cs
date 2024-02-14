using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpPaymentSetting.Dto
{
    public class SpPaymentSettingMapperProfile : Profile
    {
        public SpPaymentSettingMapperProfile()
        {
            CreateMap<SpPaymentSetting, SpPaymentSettingDto>()
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => o.FromDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => o.ToDate.HasValue ? o.ToDate.Value.ToString(Formatters.DateFormat) : string.Empty))
              ;

            CreateMap<SpPaymentSettingCreateDto, SpPaymentSetting>()
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              ;

            CreateMap<SpPaymentSettingEditDto, SpPaymentSetting>()
             .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)))
             .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
             ;
        }
    }
}
