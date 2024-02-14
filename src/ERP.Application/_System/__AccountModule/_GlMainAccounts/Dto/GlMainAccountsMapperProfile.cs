using AutoMapper;
using ERP._System._GlMainAccounts;
using ERP._System._GlMainAccounts.Dto;

namespace ERP._System.__AccountModule._GlMainAccounts.Dto
{
    public class GlMainAccountsMapperProfile : Profile
    {
        public GlMainAccountsMapperProfile()
        {

            CreateMap<GlMainAccounts, GlMainAccountsDto>()
                .ForMember(dest => dest.codeComUtilityIds, source => source.MapFrom(o => o.GlCodeComDetails.GetCodeComTextsIds("ar-EG").ids ?? string.Empty))
                .ForMember(dest => dest.codeComUtilityTexts, source => source.MapFrom(o => o.GlCodeComDetails.GetCodeComTextsIds("ar-EG").texts ?? string.Empty))
                .ForMember(dest => dest.NameArDetails, source => source.MapFrom(o => o.GlCodeComDetails.GetAttrNamesCodesNames().Item1 ?? string.Empty))
                .ForMember(dest => dest.NameEnDetails, source => source.MapFrom(o => o.GlCodeComDetails.GetAttrNamesCodesNames().Item2 ?? string.Empty))
                .ForMember(dest => dest.CodesDetails, source => source.MapFrom(o => o.GlCodeComDetails.GetAttrNamesCodesNames().Item3 ?? string.Empty))
                ;
        }
    }
}
