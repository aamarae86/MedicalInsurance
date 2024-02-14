using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    public class GlJeIntegrationHeadersMapperProfile : Profile
    {
        public GlJeIntegrationHeadersMapperProfile()
        {
            

                CreateMap<GlJeIntegrationHeaders, GlJeIntegrationHeadersDto>()
              .ForMember(dest => dest.GlJeIntegrationDate, source => source.MapFrom(o => o.GlJeIntegrationDate.ToString(Formatters.DateFormat)))
              ;

            CreateMap<GlJeIntegrationHeadersCreateDto, GlJeIntegrationHeaders>()
              .ForMember(dest => dest.GlJeIntegrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.GlJeIntegrationDate)))
              ;

            CreateMap<GlJeIntegrationHeadersEditDto, GlJeIntegrationHeaders>()
            .ForMember(dest => dest.GlJeIntegrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.GlJeIntegrationDate)))
            ;

            CreateMap<GlJeIntegrationLines, GlJeIntegrationAccountsLinesDto>()
              .ForMember(dest => dest.codeComUtilityIds, source => source.MapFrom(o => o.GlCodeComDetails.GetCodeComTextsIds("ar-EG").ids ?? string.Empty))
              .ForMember(dest => dest.codeComUtilityTexts, source => source.MapFrom(o => o.Lang == "ar-EG" ? (o.GlCodeComDetails.GetCodeComTextsIds("ar-EG").texts ?? string.Empty) 
                                                                                                           : (o.GlCodeComDetails.GetCodeComTextsIds("en-US").texts ?? string.Empty)))
              .ForMember(dest => dest.AccountNumber, source => source.MapFrom(o => o.GlCodeComDetails.GetAttrNamesCodesNames().Item3 ?? string.Empty))
              ;

            CreateMap<GlJeIntegrationAccountsLinesDto, GlJeIntegrationLines>()
             .ForMember(dest => dest.ArCustomerId, source => source.Ignore())
             .ForMember(dest => dest.ApVendorId, source => source.Ignore())
             ;

            CreateMap<GlJeIntegrationCustomersLinesDto, GlJeIntegrationLines>()
             .ForMember(dest => dest.ApVendorId, source => source.Ignore())
            ;

            CreateMap<GlJeIntegrationLines, GlJeIntegrationCustomersLinesDto>()
            .ForMember(dest => dest.CustomerNumber, source => source.MapFrom(o => o.ArCustomers.CustomerNumber))
            .ForMember(dest => dest.CustomerNameAr, source => source.MapFrom(o => o.ArCustomers.CustomerNameAr))
            .ForMember(dest => dest.CustomerNameEn, source => source.MapFrom(o => o.ArCustomers.CustomerNameEn))
           ;


            CreateMap<GlJeIntegrationVendorsLinesDto, GlJeIntegrationLines>()
             .ForMember(dest => dest.ArCustomerId, source => source.Ignore())
           ;

            CreateMap<GlJeIntegrationLines, GlJeIntegrationVendorsLinesDto>()
            .ForMember(dest => dest.VendorNumber, source => source.MapFrom(o => o.ApVendors.VendorNumber))
            .ForMember(dest => dest.VendorNameAr, source => source.MapFrom(o => o.ApVendors.VendorNameAr))
            .ForMember(dest => dest.VendorNameEn, source => source.MapFrom(o => o.ApVendors.VendorNameEn))
           ;

        }
    }
}
