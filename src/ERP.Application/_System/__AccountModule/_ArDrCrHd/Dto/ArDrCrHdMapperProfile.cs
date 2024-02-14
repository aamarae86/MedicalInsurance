using AutoMapper;
using ERP._System._ArDrCrHd;
using ERP._System._ArDrCrHd.Dto;
using ERP._System._ArDrCrTr;
using ERP._System._ArDrCrTr.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArDrCrHd.Dto
{
    public class ArDrCrHdMapperProfile : Profile
    {
        public ArDrCrHdMapperProfile()
        {
            CreateMap<ArDrCrHd, ArDrCrHdDto>()
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.GetLookupValue() ))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameEn))
               // .ForMember(dest => dest.ArDrCrTr, source => source.MapFrom(o => o.ArDrCrTr))
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => o.HdDate.HasValue ? o.HdDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<CreateArDrCrHdDto, ArDrCrHd>()
              .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ArDrCrHdEditDto, ArDrCrHd>()
              .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ArDrCrHdDto, ArDrCrHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameAr))
                .ForPath(dest => dest.FndLookupValuesStatusLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesStatusLkp.NameEn));
                       

            CreateMap<ArDrCrTrVM, ArDrCrTr>()
                .ForPath(dest => dest.ArDrCrHd.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ArDrCrHd.HdDate)))
                .ReverseMap();
        }
    }
}
