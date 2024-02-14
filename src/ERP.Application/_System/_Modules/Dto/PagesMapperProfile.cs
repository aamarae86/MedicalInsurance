using AutoMapper;
using ERP._System._modules;

namespace ERP._System._Modules.Dto
{
    public class PagesMapperProfile : Profile
    {
        public PagesMapperProfile()
        {
            CreateMap<Page, PagesDto>()
                .ForMember(o=>o.ModuleAr , c=>c.MapFrom(x=>x.Module.NameAr))
                .ForMember(o=>o.ModuleEn , c=>c.MapFrom(x=>x.Module.NameEn));

            CreateMap<PagesEditDto, Page>()
               .ForMember(o => o.Icon, c => c.MapFrom(x => $"/icons/screen name/{x.Icon}"));

        }
    }
}
