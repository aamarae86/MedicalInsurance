using AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Core.Helpers.Parameters;

namespace ERP._System._GlAccHeaders.Dto
{
    public class GlAccHeadersMapProfile : Profile
    {
        public GlAccHeadersMapProfile()
        {
            CreateMap<GetAllPagedAndSortedWithParams<GlAccHeadersSearchDto>, GetAllPagedAndSortedWithParams<GlAccHeaders>>();
            

                CreateMap<GlAccHeaders, GlAccHeadersDto>()
               .ForMember(dest => dest.CanUpdated, source => source.MapFrom(o => o.CanEditGlAccHeaders()));


        }
    }
}
