using AutoMapper;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    public class ScCampainsMapperProfile : Profile
    {
        public ScCampainsMapperProfile()
        {
            CreateMap<ScCampains, ScCampainsDto>()
                .ForMember(dest => dest.ScCampainDate, source => source.MapFrom(o => o.ScCampainDate.ToString(Formatters.DateFormat)));

            CreateMap<CreateScCampainsDto, ScCampains>()
               .ForMember(dest => dest.ScCampainDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ScCampainDate)));

            CreateMap<ScCampainsEditDto, ScCampains>()
               .ForMember(dest => dest.ScCampainDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ScCampainDate)));
        }
    }
}
