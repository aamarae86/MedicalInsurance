using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    public class TmCharityBoxActionsMapperProfile : Profile
    {
        public TmCharityBoxActionsMapperProfile()
        {
            CreateMap<TmCharityBoxActions, TmCharityBoxActionsDto>()
                .ForMember(dest => dest.ActionsDate, source => source.MapFrom(o => o.ActionsDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateTmCharityBoxActionsDto, TmCharityBoxActions>()
               .ForMember(dest => dest.ActionsDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ActionsDate)));

            CreateMap<TmCharityBoxActionsEditDto, TmCharityBoxActions>()
               .ForMember(dest => dest.ActionsDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ActionsDate)));
        }
    }
}
