using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    public class SpCasesProfile : Profile
    {
        public SpCasesProfile()
        {
            CreateMap<SpCases, SpCasesDto>()
                .ForMember(d => d.BirthDate, options => options.MapFrom(s => (s.BirthDate.HasValue) ? s.BirthDate.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.IdExpirationDate, options => options.MapFrom(s => (s.IdExpirationDate.HasValue) ? s.IdExpirationDate.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.RegistrationDate, options => options.MapFrom(s => (s.RegistrationDate.HasValue) ? s.RegistrationDate.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.StatusAr, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? "" : s.FndLookupValuesStatusLkp.NameAr))
                .ForMember(d => d.StatusEn, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? "" : s.FndLookupValuesStatusLkp.NameEn))
                .ForMember(d => d.EducationalLevelAr, options => options.MapFrom(s => s.FndLookupValuesEducationalLevelLkp.NameAr))
                .ForMember(d => d.EducationalLevelEn, options => options.MapFrom(s => s.FndLookupValuesEducationalLevelLkp.NameEn))
                .ForMember(d => d.EducationalStageAr, options => options.MapFrom(s => s.FndLookupValuesEducationalStageLkp.NameAr))
                .ForMember(d => d.EducationalStageEn, options => options.MapFrom(s => s.FndLookupValuesEducationalStageLkp.NameEn))
                .ForMember(d => d.GenderAr, options => options.MapFrom(s => s.FndLookupValuesGenderLkp.NameAr))
                .ForMember(d => d.GenderEn, options => options.MapFrom(s => s.FndLookupValuesGenderLkp.NameEn))
                .ForMember(d => d.HealthStatusAr, options => options.MapFrom(s => s.FndLookupValuesHealthStatusLkp.NameAr))
                .ForMember(d => d.HealthStatusEn, options => options.MapFrom(s => s.FndLookupValuesHealthStatusLkp.NameEn))
                .ForMember(d => d.MaritalStatusAr, options => options.MapFrom(s => s.FndLookupValuesMaritalStatusLkp.NameAr))
                .ForMember(d => d.MaritalStatusEn, options => options.MapFrom(s => s.FndLookupValuesMaritalStatusLkp.NameEn))
                .ForMember(d => d.NationalityAr, options => options.MapFrom(s => s.FndLookupValuesNationalityLkp.NameAr))
                .ForMember(d => d.NationalityEn, options => options.MapFrom(s => s.FndLookupValuesNationalityLkp.NameEn))
                .ForMember(d => d.RelativesTypeAr, options => options.MapFrom(s => s.FndLookupValuesRelativesTypeLkp.NameAr))
                .ForMember(d => d.RelativesTypeEn, options => options.MapFrom(s => s.FndLookupValuesRelativesTypeLkp.NameEn))
                .ForMember(d => d.SponsorCategoryAr, options => options.MapFrom(s => s.FndLookupValuesSponsorCategoryLkp.NameAr))
                .ForMember(d => d.SponsorCategoryEn, options => options.MapFrom(s => s.FndLookupValuesSponsorCategoryLkp.NameEn))
                .ForMember(d => d.FamilyNumber, options => options.MapFrom(s => s.SpFamilies.FamilyNumber))
                .ForMember(d => d.FamilyName, options => options.MapFrom(s => s.SpFamilies.FamilyName))
                .ForMember(d => d.GuardianName, options => options.MapFrom(s => s.SpFamilies.GuardianName))
                .ForMember(d => d.SpContractNumber, options => options.MapFrom(s => s.SpContractDetails.SpContracts.ContractNumber))
                .ForMember(d => d.SpBeneficentName, options => options.MapFrom(s => s.SpContractDetails.SpContracts.SpBeneficent.BeneficentName))
                .ReverseMap();

            CreateMap<SpCasesCreateDto, SpCases>()
                .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
                .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
                .ForMember(dest => dest.RegistrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RegistrationDate)));


            CreateMap<SpCasesEditDto, SpCases>()
                .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
                .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
                .ForMember(dest => dest.RegistrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RegistrationDate)));
        }
    }
}
