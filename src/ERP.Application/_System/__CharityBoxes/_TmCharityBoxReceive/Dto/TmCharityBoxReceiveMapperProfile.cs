using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    public class TmCharityBoxReceiveMapperProfile : Profile
    {
        public TmCharityBoxReceiveMapperProfile()
        {
            CreateMap<TmCharityBoxReceive, TmCharityBoxReceiveDto>()
                .ForMember(dest => dest.ReceiveDate, source => source.MapFrom(o => o.ReceiveDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateTmCharityBoxReceiveDto, TmCharityBoxReceive>()
                .ForMember(dest => dest.ReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ReceiveDate)));

            CreateMap<TmCharityBoxReceiveEditDto, TmCharityBoxReceive>()
                .ForMember(dest => dest.ReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ReceiveDate)));
        }
    }
}
