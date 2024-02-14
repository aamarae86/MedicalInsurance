using AutoMapper;
using ERP._System.__HR._HrPersons._HrPersonIdentityCard;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__HR._HrPersons.Dto
{
    public class HrPersonsMapperProfile : Profile
    {
        public HrPersonsMapperProfile()
        {
            CreateMap<HrPersons, HrPersonsDto>()
               .ForMember(dest => dest.ProbationEndDate, source => source.MapFrom(o => o.ProbationEndDate == null ? string.Empty : o.ProbationEndDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => o.HireDate.ToString(Formatters.DateFormat)));

            CreateMap<HrPersonsCreateDto, HrPersons>()
               .ForMember(dest => dest.ProbationEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ProbationEndDate)))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HireDate)));

            CreateMap<HrPersonsEditDto, HrPersons>()
               .ForMember(dest => dest.ProbationEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ProbationEndDate)))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HireDate)));

            CreateMap<HrPersonVisaDetailsDto, HrPersonVisaDetails>()
              .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DateOfExpiry)))
              .ForMember(dest => dest.DateOfIssue, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DateOfIssue)));

            CreateMap<HrPersonVisaDetails, HrPersonVisaDetailsDto>()
               .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => o.DateOfExpiry.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.DateOfIssue, source => source.MapFrom(o => o.DateOfIssue.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.IssuedByLkp, source => source.MapFrom(o => o.FndIssuedByLkp.GetLookupValue()))
               .ForMember(dest => dest.PlaceOfIssueLkp, source => source.MapFrom(o => o.FndPlaceOfIssueLkp.GetLookupValue()))
               .ForMember(dest => dest.VisaTypeLkp, source => source.MapFrom(o => o.FndVisaTypeLkp.GetLookupValue()))
               .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction));


            CreateMap<HrPersonPassportDetailsDto, HrPersonPassportDetails>()
              .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DateOfExpiry)))
              .ForMember(dest => dest.DateOfIssue, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DateOfIssue)));

            CreateMap<HrPersonPassportDetails, HrPersonPassportDetailsDto>()
              .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => o.DateOfExpiry.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.DateOfIssue, source => source.MapFrom(o => o.DateOfIssue.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.CountryOfIssueLkp, source => source.MapFrom(o => o.FndCountryOfIssueLkp.GetLookupValue()))
              .ForMember(dest => dest.PassportTypeLkp, source => source.MapFrom(o => o.FndPassportTypeLkp.GetLookupValue()))
              .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction));

            CreateMap<HrPersonIdentityCardDto, HrPersonIdentityCard>()
              .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DateOfExpiry)));

            CreateMap<HrPersonIdentityCard, HrPersonIdentityCardDto>()
             .ForMember(dest => dest.DateOfExpiry, source => source.MapFrom(o => o.DateOfExpiry == null ? string.Empty : o.DateOfExpiry.Value.ToString(Formatters.DateFormat)))
             .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction));

            CreateMap<HrPersonSalaryElements, HrPersonSalaryElementsDto>()
             .ForMember(dest => dest.PyElementName, source => source.MapFrom(o => o.PyElements.ElementName))
             .ForMember(dest => dest.StartPeriodNameAr, source => source.MapFrom(o => o.StartPeriods.PeriodNameAr))
             .ForMember(dest => dest.StartPeriodNameEn, source => source.MapFrom(o => o.StartPeriods.PeriodNameEn))
             .ForMember(dest => dest.EndPeriodNameAr, source => source.MapFrom(o => o.EndPeriods.PeriodNameAr))
             .ForMember(dest => dest.EndPeriodNameEn, source => source.MapFrom(o => o.EndPeriods.PeriodNameEn))
             .ForMember(dest => dest.startPeriod, source => source.MapFrom(o => new PeriodsDates { startDate = o.StartPeriods.StartDate.ToString(Formatters.DateFormat), endDate = o.StartPeriods.EndDate.ToString(Formatters.DateFormat) }))
             .ForMember(dest => dest.endPeriod, source => source.MapFrom(o => new PeriodsDates { startDate = o.EndPeriods.StartDate.ToString(Formatters.DateFormat), endDate = o.EndPeriods.EndDate.ToString(Formatters.DateFormat) }))
             .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction));
        }
    }
}
