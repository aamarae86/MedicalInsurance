using AutoMapper;
using ERP._System.__AccountModule._ApDrCrTr;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
using ERP._System._ArDrCrHd;
using ERP._System._ArDrCrHd.Dto;
using ERP._System._ArDrCrTr;
using ERP._System._ArDrCrTr.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    public class ApDrCrHdMapperProfile : Profile
    {
        public ApDrCrHdMapperProfile()
        {
            CreateMap<ApDrCrHd, ApDrCrHdDto>()
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.GetLookupValue()))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameEn))
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => o.HdDate.HasValue ? o.HdDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<ApDrCrHdCreateDto, ApDrCrHd>()
              .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ApDrCrHdEditDto, ApDrCrHd>()
              .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ApDrCrHdDto, ApDrCrHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameAr))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameEn));

            CreateMap<ApDrCrTrDto, ApDrCrTr>()
                .ForPath(dest => dest.ApDrCrHd.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ApDrCrHd.HdDate)))
                .ReverseMap();

        }
    }
}
