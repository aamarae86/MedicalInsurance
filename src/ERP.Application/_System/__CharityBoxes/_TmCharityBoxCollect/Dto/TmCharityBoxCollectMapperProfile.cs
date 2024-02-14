using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{
    public class TmCharityBoxCollectMapperProfile : Profile
    {
        public TmCharityBoxCollectMapperProfile()
        {
            CreateMap<TmCharityBoxCollect, TmCharityBoxCollectDto>()
              .ForMember(dest => dest.CollectDate, source => source.MapFrom(o => o.CollectDate.ToString(Formatters.DateFormat)));

            CreateMap<TmCharityBoxCollectCreateDto, TmCharityBoxCollect>()
              .ForMember(dest => dest.CollectDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CollectDate)));

            CreateMap<TmCharityBoxCollectEditDto, TmCharityBoxCollect>()
              .ForMember(dest => dest.CollectDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CollectDate)));
        }
    }
}