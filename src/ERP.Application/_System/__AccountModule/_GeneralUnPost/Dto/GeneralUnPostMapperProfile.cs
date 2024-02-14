using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._GeneralUnPost.Dto
{
    public class GeneralUnPostMapperProfile : Profile
    {
        public GeneralUnPostMapperProfile()
        {
            CreateMap<GeneralUnPost, GeneralUnPostDto>()
                  .ForMember(dest => dest.UnPostDate, source => source.MapFrom(o => o.UnPostDate.ToString(Formatters.DateFormat)));
        }
    }
}
