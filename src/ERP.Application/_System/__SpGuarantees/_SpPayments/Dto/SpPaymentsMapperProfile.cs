using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    public class SpPaymentsMapperProfile : Profile
    {
        public SpPaymentsMapperProfile()
        {
            CreateMap<SpPayments, SpPaymentsDto>()
             .ForMember(dest => dest.CaseNumber, source => source.MapFrom(o => o.SpCases.CaseNumber))
             ;

            CreateMap<SpPaymentPersons, SpPaymentPersonsDto>()
              .ForMember(dest => dest.CaseStatusAr, source => source.MapFrom(o => o.SpCases.FndLookupValuesStatusLkp.NameAr))
              .ForMember(dest => dest.CaseStatusEn, source => source.MapFrom(o => o.SpCases.FndLookupValuesStatusLkp.NameEn))
              .ForMember(dest => dest.SponsorCategoryAr, source => source.MapFrom(o => o.SpCases.FndLookupValuesSponsorCategoryLkp.NameEn))
              .ForMember(dest => dest.SponsorCategoryEn, source => source.MapFrom(o => o.SpCases.FndLookupValuesSponsorCategoryLkp.NameEn))
              .ForMember(dest => dest.CaseNumber, source => source.MapFrom(o => o.SpCases.CaseNumber))
              .ForMember(dest => dest.CaseName, source => source.MapFrom(o => o.SpCases.CaseName))
              ;

            CreateMap<SpPaymentPersonDetails, SpPaymentPersonDetailsDto>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.Period.StartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.Period.EndDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.StatusAr, source => source.MapFrom(o => o.SpContractDetails.FndCaseStatusLkp.NameAr))
               .ForMember(dest => dest.StatusEn, source => source.MapFrom(o => o.SpContractDetails.FndCaseStatusLkp.NameEn))
               .ForMember(dest => dest.CaseName, source => source.MapFrom(o => o.SpContractDetails.SpCases.CaseName))
               .ForMember(dest => dest.PeriodAr, source => source.MapFrom(o => o.Period.PeriodNameAr))
               .ForMember(dest => dest.PeriodEn, source => source.MapFrom(o => o.Period.PeriodNameEn))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => o.ContractStartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => o.ContractEndDate.HasValue ? o.ContractEndDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               ;
        }
    }
}
