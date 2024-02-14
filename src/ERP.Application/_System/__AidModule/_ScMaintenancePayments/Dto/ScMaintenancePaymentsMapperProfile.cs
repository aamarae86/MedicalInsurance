using AutoMapper;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScMaintenancePayments.Dto
{
    public class ScMaintenancePaymentsMapperProfile : Profile
    {
        public ScMaintenancePaymentsMapperProfile()
        {
            CreateMap<ScMaintenancePayments, ScMaintenancePaymentsDto>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.MaintenancePaymentDate, source => source.MapFrom(o => o.MaintenancePaymentDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ScMaintenanceContractId, source => source.MapFrom(o => o.ScMaintenanceContractPayments.ScMaintenanceContractId))
              .ForMember(dest => dest.MaintenanceContractNumber, source => source.MapFrom(o => o.ScMaintenanceContractPayments.ScMaintenanceContract.MaintenanceContractNumber))
              .ForMember(dest => dest.MaintenanceContractPaymentsNumber, source => source.MapFrom(o => o.ScMaintenanceContractPayments.PayemtNo))
              .ForMember(dest => dest.PortalRequestNumber, source => source.MapFrom(o => o.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber))
              .ForMember(dest => dest.PortalUserName, source => source.MapFrom(o => o.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser.Name))
              .ForMember(dest => dest.Vendor, source => source.MapFrom(o => o.ScMaintenanceContractPayments.ScMaintenanceContract.ScMaintenanceQuotations.ApVendors.VendorNameAr))
              ;

            CreateMap<ScMaintenancePaymentsCreateDto, ScMaintenancePayments>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
               .ForMember(dest => dest.MaintenancePaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaintenancePaymentDate)))
               ;

            CreateMap<ScMaintenancePaymentsEditDto, ScMaintenancePayments>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
               .ForMember(dest => dest.MaintenancePaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaintenancePaymentDate)))
               ;

            CreateMap<ScMaintenancePayments, ScMaintenanceContractPaymentsDto>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.ScMaintenanceContractPayments.MaturityDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.Amount, source => source.MapFrom(o => o.Amount))
               .ForMember(dest => dest.PayemtNo, source => source.MapFrom(o => o.ScMaintenanceContractPayments.PayemtNo))
               ;
        }
    }
}
