using AutoMapper;

namespace ERP._System.__CharityBoxes._TmCharityBoxes.Dto
{
    public class CharityBoxMapProfile : Profile
    {
        public CharityBoxMapProfile()
        {
            CreateMap<TmCharityBoxes, TmCharityBoxesDto>()
                .ForMember(m => m.CityName, options => options.MapFrom(input => input.TmSubLocation.TmLocation.Region.FndLookupValues.NameAr))
                .ForMember(m => m.RegionName, options => options.MapFrom(input => input.TmSubLocation.TmLocation.Region.RegionName))
                .ForMember(m => m.LocationName, options => options.MapFrom(input => input.TmSubLocation.TmLocation.LocationName))
                .ForMember(m => m.SubLocationName, options => options.MapFrom(input => input.TmSubLocation.TmLocationSubName));
        }

    }
}
