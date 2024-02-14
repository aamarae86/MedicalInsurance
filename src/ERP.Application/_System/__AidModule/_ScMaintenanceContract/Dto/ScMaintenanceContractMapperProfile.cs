using AutoMapper;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    public class ScMaintenanceContractMapperProfile : Profile
    {
        public ScMaintenanceContractMapperProfile()
        {
            CreateMap<ScMaintenanceContract, ScMaintenanceContractDto>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.HasValue ? o.StartDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               .ForMember(dest => dest.MaintenanceContractDate, source => source.MapFrom(o => o.MaintenanceContractDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.PortalRequestNumber, source => source.MapFrom(o => o.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber))
               .ForMember(dest => dest.PortalUserName, source => source.MapFrom(o => o.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser.Name))
               .ForMember(dest => dest.Vendor, source => source.MapFrom(o => o.ScMaintenanceQuotations.ApVendors.VendorNameAr))
               .ForMember(dest => dest.TotalAmount, source => source.MapFrom(o => o.ScMaintenanceQuotations.ScMaintenanceQuotationDetails.Sum(x => x.Amount)))
               ;

            CreateMap<ScMaintenanceContractCreateDto, ScMaintenanceContract>()
               .ForMember(dest => dest.MaintenanceContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaintenanceContractDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               ;

            CreateMap<ScMaintenanceContractEditDto, ScMaintenanceContract>()
               .ForMember(dest => dest.MaintenanceContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaintenanceContractDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               ;

            CreateMap<ScMaintenanceContractPaymentsDto, ScMaintenanceContractPayments>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
               ;

            CreateMap<ScMaintenanceContractPayments, ScMaintenanceContractPaymentsDto>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.ToString(Formatters.DateFormat)))
              ;
        }
    }
}
