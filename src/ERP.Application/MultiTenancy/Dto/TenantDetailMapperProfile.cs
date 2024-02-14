using AutoMapper;

namespace ERP.MultiTenancy.Dto
{
    public class TenantDetailMapperProfile : Profile
    {
        public TenantDetailMapperProfile()
        {
            //CreateMap<TenantDetail, TenantDetailDto>()
            //   .ForMember(dest => dest.CountryAr, source => source.MapFrom(o => o.Tenant.FndCountryLkp.NameAr))
            //   .ForMember(dest => dest.CountryEn, source => source.MapFrom(o => o.Tenant.FndCountryLkp.NameEn))
            //   .ForMember(dest => dest.IndustryAr, source => source.MapFrom(o => o.Tenant.FndIndustryLkp.NameAr))
            //   .ForMember(dest => dest.IndustryEn, source => source.MapFrom(o => o.Tenant.FndIndustryLkp.NameEn))
            //   .ForMember(dest => dest.CurrencyId, source => source.MapFrom(o => o.Tenant.BaseCurrency))
            //   .ForMember(dest => dest.CurrencyCode, source => source.MapFrom(o => o.Tenant.Currency.Code))
            //   .ForMember(dest => dest.CurrencyAr, source => source.MapFrom(o => o.Tenant.Currency.MainCurrencyNameAr))
            //   .ForMember(dest => dest.CurrencyEn, source => source.MapFrom(o => o.Tenant.Currency.MainCurrencyNameEn));

            CreateMap<Tenant, TenantDetailDto>()
             .ForMember(dest => dest.CountryAr, source => source.MapFrom(o => o.FndCountryLkp.NameAr))
             .ForMember(dest => dest.CountryEn, source => source.MapFrom(o => o.FndCountryLkp.NameEn))
             .ForMember(dest => dest.IndustryAr, source => source.MapFrom(o => o.FndIndustryLkp.NameAr))
             .ForMember(dest => dest.IndustryEn, source => source.MapFrom(o => o.FndIndustryLkp.NameEn))
             .ForMember(dest => dest.CurrencyId, source => source.MapFrom(o => o.BaseCurrency))
             .ForMember(dest => dest.CurrencyCode, source => source.MapFrom(o => o.Currency.Code))
             .ForMember(dest => dest.CurrencyAr, source => source.MapFrom(o => o.Currency.DescriptionAr))
             .ForMember(dest => dest.CurrencyEn, source => source.MapFrom(o => o.Currency.DescriptionEn))
            .ForMember(dest => dest.TenantNameAr, source => source.MapFrom(o => o.TenantNameAr))
            .ForMember(dest => dest.TenantNameEn, source => source.MapFrom(o => o.TenantNameEn));

            CreateMap<Tenant, TenantDetailEditDto>()
           .ForMember(dest => dest.CountryAr, source => source.MapFrom(o => o.FndCountryLkp.NameAr))
           .ForMember(dest => dest.CountryEn, source => source.MapFrom(o => o.FndCountryLkp.NameEn))
           .ForMember(dest => dest.IndustryAr, source => source.MapFrom(o => o.FndIndustryLkp.NameAr))
           .ForMember(dest => dest.IndustryEn, source => source.MapFrom(o => o.FndIndustryLkp.NameEn))
           .ForMember(dest => dest.CurrencyId, source => source.MapFrom(o => o.BaseCurrency))
           .ForMember(dest => dest.CurrencyCode, source => source.MapFrom(o => o.Currency.Code))
           .ForMember(dest => dest.CurrencyAr, source => source.MapFrom(o => o.Currency.DescriptionAr))
           .ForMember(dest => dest.CurrencyEn, source => source.MapFrom(o => o.Currency.DescriptionEn));


            CreateMap<Tenant, CreateTenantDto>()
           .ForMember(dest => dest.TenancyName, source => source.MapFrom(o => o.TenantNameAr))
           .ForMember(dest => dest.TenancyName, source => source.MapFrom(o => o.TenantNameEn));

            //CreateMap<TenantDetail, TenantDetailEditDto>()
            //   .ForMember(dest => dest.CountryAr, source => source.MapFrom(o => o.Tenant.FndCountryLkp.NameAr))
            //   .ForMember(dest => dest.CountryEn, source => source.MapFrom(o => o.Tenant.FndCountryLkp.NameEn))
            //   .ForMember(dest => dest.IndustryAr, source => source.MapFrom(o => o.Tenant.FndIndustryLkp.NameAr))
            //   .ForMember(dest => dest.IndustryEn, source => source.MapFrom(o => o.Tenant.FndIndustryLkp.NameEn))
            //   .ForMember(dest => dest.CurrencyCode, source => source.MapFrom(o => o.Tenant.Currency.Code))
            //   .ForMember(dest => dest.CurrencyAr, source => source.MapFrom(o => o.Tenant.Currency.DescriptionAr))
            //   .ForMember(dest => dest.CurrencyEn, source => source.MapFrom(o => o.Tenant.Currency.MainCurrencyNameEn));
        }
    }

}
