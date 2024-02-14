using AutoMapper;
using ERP._System._ArCustomers.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmTenants.Dto
{
    public class PmTenantsMapProfile : Profile
    {
        public PmTenantsMapProfile()
        {
            CreateMap<PmTenants, PmTenantsDto>()
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => o.PassportExpiryDate == null ? string.Empty : o.PassportExpiryDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => o.PassportIssueDate == null ? string.Empty : o.PassportIssueDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => o.ResidenceEndDate == null ? string.Empty : o.ResidenceEndDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate == null ? string.Empty : o.BirthDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.CommercialLicenseExpiryDate, source => source.MapFrom(o => o.CommercialLicenseExpiryDate == null ? string.Empty : o.CommercialLicenseExpiryDate.Value.ToString(Formatters.DateFormat)));

            CreateMap<PmTenantsCreateDto, PmTenants>()
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
              .ForMember(dest => dest.CommercialLicenseExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CommercialLicenseExpiryDate)))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)));

            CreateMap<PmTenantsEditDto, PmTenants>()
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
              .ForMember(dest => dest.CommercialLicenseExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CommercialLicenseExpiryDate)))
              .ForMember(dest => dest.PassportExpiryDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportExpiryDate)))
              .ForMember(dest => dest.PassportIssueDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PassportIssueDate)))
              .ForMember(dest => dest.ResidenceEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ResidenceEndDate)));

            CreateMap<PmTenantsCreateDto, CreateArCustomersDto>()
                .ForMember(t => t.Address, options => options.MapFrom(input => input.Address))
                .ForMember(t => t.CustomerNameAr, options => options.MapFrom(input => input.TenantNameAr))
                .ForMember(t => t.CustomerNameEn, options => options.MapFrom(input => input.TenantNameEn))
                .ForMember(t => t.CustomerTypeLkpId, options => options.MapFrom(input => 27))
                .ForMember(t => t.Email, options => options.MapFrom(input => input.EmailAddress))
                .ForMember(t => t.Fax, options => options.MapFrom(input => input.Fax))
                .ForMember(t => t.HomeTel, options => options.MapFrom(input => input.HomePhoneNumber))
                .ForMember(t => t.Mobile, options => options.MapFrom(input => input.MobileNumber))
                .ForMember(t => t.StatusLkpId, options => options.MapFrom(o => 23))
                .ForMember(t => t.Website, options => options.MapFrom(input => input.Website))
                .ForMember(t => t.WorkTel, options => options.MapFrom(input => input.WorkPhoneNumber))
                .ForMember(t => t.SourceCodeLkpId, options => options.MapFrom(input => 285))
                ;


            CreateMap<PmTenantsEditDto, ArCustomersEditDto>()
                .ForMember(t => t.Address, options => options.MapFrom(input => input.Address))
                .ForMember(t => t.CustomerNameAr, options => options.MapFrom(input => input.TenantNameAr))
                .ForMember(t => t.CustomerNameEn, options => options.MapFrom(input => input.TenantNameEn))
                .ForMember(t => t.CustomerTypeLkpId, options => options.MapFrom(input => 27))
                .ForMember(t => t.Email, options => options.MapFrom(input => input.EmailAddress))
                .ForMember(t => t.Fax, options => options.MapFrom(input => input.Fax))
                .ForMember(t => t.HomeTel, options => options.MapFrom(input => input.HomePhoneNumber))
                .ForMember(t => t.Mobile, options => options.MapFrom(input => input.MobileNumber))
                .ForMember(t => t.StatusLkpId, options => options.MapFrom(o => 23))
                .ForMember(t => t.Website, options => options.MapFrom(input => input.Website))
                .ForMember(t => t.WorkTel, options => options.MapFrom(input => input.WorkPhoneNumber))
                ;


            CreateMap<PmTenantsDto, ArCustomersDto>()
                .ForMember(t => t.Address, options => options.MapFrom(input => input.Address))
                .ForMember(t => t.CustomerNameAr, options => options.MapFrom(input => input.TenantNameAr))
                .ForMember(t => t.CustomerNameEn, options => options.MapFrom(input => input.TenantNameEn))
                .ForMember(t => t.CustomerTypeLkpId, options => options.MapFrom(input => 27))
                .ForMember(t => t.Email, options => options.MapFrom(input => input.EmailAddress))
                .ForMember(t => t.Fax, options => options.MapFrom(input => input.Fax))
                .ForMember(t => t.HomeTel, options => options.MapFrom(input => input.HomePhoneNumber))
                .ForMember(t => t.Mobile, options => options.MapFrom(input => input.MobileNumber))
                .ForMember(t => t.StatusLkpId, options => options.MapFrom(o => 23))
                .ForMember(t => t.Website, options => options.MapFrom(input => input.Website))
                .ForMember(t => t.WorkTel, options => options.MapFrom(input => input.WorkPhoneNumber))
                .ForMember(t => t.SourceCodeLkpId, options => options.MapFrom(input => 285))
                .ForMember(t => t.SourceId, options => options.MapFrom(input => input.Id))
                ;
        }
    }
}
