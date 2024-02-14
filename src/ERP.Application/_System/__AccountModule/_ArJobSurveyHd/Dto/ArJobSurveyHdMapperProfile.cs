using AutoMapper;
using ERP._System._ArJobSurveyHd;
using ERP._System._ArJobSurveyHd.Dto;
using ERP._System._ArDrCrTr;
using ERP._System._ArDrCrTr.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP._System.__AccountModule._ArJobSurveyTr;

namespace ERP._System.__AccountModule._ArJobSurveyHd.Dto
{
    public class ArJobSurveyHdMapperProfile : Profile
    {
        public ArJobSurveyHdMapperProfile()
        {
            CreateMap<ArJobSurveyHd, ArJobSurveyHdDto>()
                 
                .ForMember(dest => dest.ClaimDate, source => source.MapFrom(o => o.ClaimDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateArJobSurveyHdDto, ArJobSurveyHd>()
              .ForMember(dest => dest.ClaimDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ClaimDate)));

            CreateMap<ArJobSurveyHdEditDto, ArJobSurveyHd>()
              .ForMember(dest => dest.ClaimDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ClaimDate)))
              .ForMember(dest=>dest.ArJobSurveyTr,source=>source.Ignore());

            CreateMap<ArJobSurveyHdDto, ArJobSurveyHd>()
                .ForMember(dest => dest.ClaimDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ClaimDate)))
                 ;


            CreateMap<ArJobSurveyTrDto, ArJobSurveyTr>();
                 
                

            CreateMap<ArJobSurveyTr, ArJobSurveyTrDto>()
                .ForMember(dest => dest.PartsCategoryName, source => source.MapFrom(o => o.PartsCategoryLkp.NameEn))
                .ForMember(dest => dest.SurveyPartsName, source => source.MapFrom(o => o.ArJobSurveyPartsList.PartsName))
                ;
        }
    }
}
