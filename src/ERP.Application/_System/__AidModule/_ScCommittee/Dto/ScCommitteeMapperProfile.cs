using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    public class ScCommitteeMapperProfile : Profile
    {
        public ScCommitteeMapperProfile()
        {
            CreateMap<ScCommittee, ScCommitteeDto>()
               .ForMember(dest => dest.CommitteeDate, source => source.MapFrom(o => o.CommitteeDate.ToString(Formatters.DateFormat)));

            CreateMap<ScCommitteeCreateDto, ScCommittee>()
               .ForMember(dest => dest.CommitteeDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CommitteeDate)));

            CreateMap<ScCommitteeEditDto, ScCommittee>()
              .ForMember(dest => dest.CommitteeDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CommitteeDate)));
        }
    }
}
