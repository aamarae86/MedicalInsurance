using AutoMapper;

namespace ERP._System.Home.Dto
{
    public class FavoritePageMapperProfile : Profile
    {
        public FavoritePageMapperProfile()
        {
            CreateMap<FavoritePage, FavoritePageDto>()
               .ForMember(dest => dest.UserId, source => source.MapFrom(o => o.CreatorUserId))
               .ForMember(dest => dest.Link, source => source.MapFrom(o => o.Page.Link))
               .ForMember(dest => dest.Icon, source => source.MapFrom(o => o.Page.Icon))
               .ForMember(dest => dest.PageSelector, source => source.MapFrom(o => o.Page.Selector))
               .ForMember(dest => dest.PageNameAr, source => source.MapFrom(o => o.Page.NameAr))
               .ForMember(dest => dest.PageNameEn, source => source.MapFrom(o => o.Page.NameEn));

            CreateMap<FavoritePageDto, FavoritePage>();

            CreateMap<FavoritePageCreateDto, FavoritePage>().ReverseMap();
        }
    }
}
