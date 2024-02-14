using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    public class TmDamagedCharityBoxsMapperProfile : Profile
    {
        public TmDamagedCharityBoxsMapperProfile()
        {
            CreateMap<TmDamagedCharityBoxs, TmDamagedCharityBoxsDto>()
              .ForMember(dest => dest.DamagedCharityBoxsDate, source => source.MapFrom(o => o.DamagedCharityBoxsDate.ToString(Formatters.DateFormat)));

            CreateMap<TmDamagedCharityBoxsCreateDto, TmDamagedCharityBoxs>()
             .ForMember(dest => dest.DamagedCharityBoxsDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DamagedCharityBoxsDate)));

            CreateMap<TmDamagedCharityBoxsEditDto, TmDamagedCharityBoxs>()
             .ForMember(dest => dest.DamagedCharityBoxsDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DamagedCharityBoxsDate)));
        }
    }
}
