using AutoMapper;
using ERP._System.__AidModule._Portal._PortalUserDuties;
using ERP._System.__AidModule._Portal._PortalUserIncomes;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AidModule._PortalUserData.Dto;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System._Portal;
using ERP._System._Portal.UserRelatives.Dto;
using ERP.Authorization.Users;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedMapperProfile : Profile
    {
        public PortalUserUnifiedMapperProfile()
        {
            CreateMap<PortalUser, PortalUserData>();

            CreateMap<PortalUserUnifiedCreateDto, PortalUserDataCreateDto>();

            CreateMap<PortalUserUnifiedEditDto, PortalUserUnifiedDto>();

            CreateMap<PortalUserUnifiedEditDto, PortalUserData>();

            CreateMap<PortalUserData, PortalUserDataDto>()
              .ForMember(t => t.Name, options => options.MapFrom(input => input.PortalUser.Name))
              .ForMember(t => t.IdNumber, options => options.MapFrom(input => input.PortalUser.IdNumber))
              .ForMember(t => t.CaseNumber, options => options.MapFrom(input => input.PortalUser.CaseNumber))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => o.PassportExpiryDate == null ? string.Empty : o.PassportExpiryDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => o.PassportIssueDate == null ? string.Empty : o.PassportIssueDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => o.ResidenceEndDate == null ? string.Empty : o.ResidenceEndDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)))
                ;

            CreateMap<PortalUserData, PortalUserDataDto>()
              .ForMember(t => t.NationalityFndLookupValues, options => options.MapFrom(input => input.PortalUser.NationalityFndLookupValues))
              .ForMember(t => t.UserDuties, options => options.MapFrom(input => input.PortalUserDuties))
              .ForMember(t => t.UserIncomes, options => options.MapFrom(input => input.PortalUserIncomes))
              .ForMember(t => t.Name, options => options.MapFrom(input => input.PortalUser.Name))
              .ForMember(t => t.IdNumber, options => options.MapFrom(input => input.PortalUser.IdNumber))
              .ForMember(t => t.CaseNumber, options => options.MapFrom(input => input.PortalUser.CaseNumber))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => o.PassportExpiryDate == null ? string.Empty : o.PassportExpiryDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => o.PassportIssueDate == null ? string.Empty : o.PassportIssueDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => o.ResidenceEndDate == null ? string.Empty : o.ResidenceEndDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)))
              .ReverseMap();

            CreateMap<PortalUserData, PortalUserDataCreateDto>()
               .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => o.PassportExpiryDate == null ? string.Empty : o.PassportExpiryDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => o.PassportIssueDate == null ? string.Empty : o.PassportIssueDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => o.ResidenceEndDate == null ? string.Empty : o.ResidenceEndDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)))
               ;

            CreateMap<PortalUserDataCreateDto, PortalUserData>()
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
               .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
               .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
               ;

            CreateMap<PortalUserDataEditDto, PortalUserData>()
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
               .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
               .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
               ;

            CreateMap<PortalUserIncomes, ScPortalRequestIncomeDto>()
              .ForMember(t => t.MonthlyIncomeAmount, options => options.MapFrom(input => input.MonthlyIncomeAmount))
              .ForMember(t => t.IncomeSourceName, options => options.MapFrom(input => input.IncomeSourceName))
              .ForMember(t => t.Id, options => options.MapFrom(input => 0))
              .ReverseMap();


            CreateMap<PortalUserDuties, ScPortalRequestDutiesDto>()
                .ForMember(t => t.DutyType, options => options.MapFrom(input => input.DutyType))
                .ForMember(t => t.DutyDescription, options => options.MapFrom(input => input.DutyDescription))
                .ForMember(t => t.MonthlyAmount, options => options.MapFrom(input => input.MonthlyAmount))
                .ForMember(t => t.Id, options => options.MapFrom(input => 0))
                .ReverseMap();

            CreateMap<PortalUserRelatives, PortalUserRelativesDto>()
               .ForMember(dest => dest.genderLkp, options => options.MapFrom(input => input.GenderFndLookupValues.NameAr))
               .ForMember(dest => dest.maritalStatusLkp, options => options.MapFrom(input => input.MaritalStatusFndLookupValues.NameAr))
               .ForMember(dest => dest.qualificationLkp, options => options.MapFrom(input => input.QualificationFndLookupValues.NameAr))
               .ForMember(dest => dest.nationalityLkp, options => options.MapFrom(input => input.NationalityFndLookupValues.NameAr))
               .ForMember(dest => dest.relativesTypeLkp, options => options.MapFrom(input => input.RelativesFndLookupValues.NameAr));

            CreateMap<PortalUser, PortalUserUnifiedDto>()
               .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => o.PassportExpiryDate == null ? string.Empty : o.PassportExpiryDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => o.PassportIssueDate == null ? string.Empty : o.PassportIssueDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => o.ResidenceEndDate == null ? string.Empty : o.ResidenceEndDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)))
               ;

            CreateMap<PortalUserUnifiedCreateDto, PortalUser>()
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)))
              .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
              ;

            CreateMap<PortalUserUnifiedEditDto, PortalUser>()
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)))
              .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
              ;
        }
    }
}
