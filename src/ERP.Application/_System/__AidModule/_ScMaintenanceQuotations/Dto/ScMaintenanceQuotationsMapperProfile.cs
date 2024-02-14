using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    public class ScMaintenanceQuotationsMapperProfile : Profile
    {
        public ScMaintenanceQuotationsMapperProfile()
        {
            CreateMap<ScMaintenanceQuotations, ScMaintenanceQuotationsDto>()
                .ForMember(dest => dest.QuotationDate, source => source.MapFrom(o => o.QuotationDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.PortalRequestNumber, source => source.MapFrom(o => o.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber))
                .ForMember(dest => dest.PortalUserName, source => source.MapFrom(o => o.ScMaintenanceTechnicalReport.PortalRequest.PortalUser.Name))
                ;

            CreateMap<ScMaintenanceQuotationsCreateDto, ScMaintenanceQuotations>()
               .ForMember(dest => dest.QuotationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.QuotationDate)));

            CreateMap<ScMaintenanceQuotationsEditDto, ScMaintenanceQuotations>()
               .ForMember(dest => dest.QuotationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.QuotationDate)));

            CreateMap<ScMaintenanceQuotationDetails, ScMaintenanceQuotationDetailsDto>()
              .ForMember(dest => dest.MaintenanceTechnicalReportItemDescription, source => source.MapFrom(o => o.ScMaintenanceTechnicalReportDetail.ItemDescription));
        }
    }
}
