using AutoMapper;
using ERP._System.__AccountModule._GlJeHeaders.Dto;
using ERP._System._GlPeriods;
using ERP.Core.Helpers.Parameters;
using ERP.Helpers.Core;
using System;

namespace ERP._System._GlJeHeaders.Dto
{
    public class GlJeHeadersMapProfile : Profile
    {
        public GlJeHeadersMapProfile()
        {
            CreateMap<GetAllPagedAndSortedWithParams<GlJeHeadersSearchDto>, GetAllPagedAndSortedWithParams<GlJeHeaders>>();

            CreateMap<GlJeHeaders, GlJeHeadersDetailDto>()
                .ForMember(dest => dest.JeDate, source => source.MapFrom(o => o.JeDate.ToString(Formatters.DateFormat)));

            CreateMap<GlJeHeaders, GlJeHeadersDto>()
                .ForMember(dest => dest.JeDate, source => source.MapFrom(o => o.JeDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateGlJeHeadersDto, GlJeHeaders>()
                .ForMember(dest => dest.JeDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.JeDate)));

            CreateMap<GlJeHeadersEditDto, GlJeHeaders>()
               .ForMember(dest => dest.JeDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.JeDate)));
        }
    }
}
