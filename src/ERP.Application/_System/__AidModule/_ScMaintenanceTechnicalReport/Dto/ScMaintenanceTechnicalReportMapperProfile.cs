using AutoMapper;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    public class ScMaintenanceTechnicalReportMapperProfile : Profile
    {
        public ScMaintenanceTechnicalReportMapperProfile()
        {
            CreateMap<ScMaintenanceTechnicalReport, ScMaintenanceTechnicalReportDto>()
              .ForMember(dest => dest.TechnicalReportDate, source => source.MapFrom(o => o.TechnicalReportDate.ToString(Formatters.DateFormat)))
              ;

            CreateMap<ScMaintenanceTechnicalReportCreateDto, ScMaintenanceTechnicalReport>()
              .ForMember(dest => dest.TechnicalReportDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TechnicalReportDate)))
              ;

            CreateMap<ScMaintenanceTechnicalReportEditDto, ScMaintenanceTechnicalReport>()
              .ForMember(dest => dest.TechnicalReportDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TechnicalReportDate)))
            ;

            CreateMap<ScMaintenanceTechnicalReportDetail, ScMaintenanceTechnicalReportDetailDto>()
              ;

            CreateMap<ScMaintenanceTechnicalReportDetailDto, ScMaintenanceTechnicalReportDetail>()
             ;

            CreateMap<ScMaintenanceTechnicalReportAttachmentsDto, ScMaintenanceTechnicalReportAttachments>()
            ;

            CreateMap<ScMaintenanceTechnicalReportDetail, ScMaintenanceTechnicalReportDetailDto>()
           ;

            CreateMap<ScMaintenanceTechnicalReportAttachments, ScMaintenanceTechnicalReportAttachmentsDto>()
            ;

            CreateMap<ScMaintenanceQuotations, ScMaintenanceTechnicalReportQuotationsDto>()
                 .ForMember(dest => dest.QuotationDate, source => source.MapFrom(o => o.QuotationDate.ToString(Formatters.DateFormat)))
                 .ForMember(dest => dest.StatusAr, source => source.MapFrom(o => o.FndStatusLkp.NameAr))
                 .ForMember(dest => dest.StatusEn, source => source.MapFrom(o => o.FndStatusLkp.NameEn))
                 .ForMember(dest => dest.VendorAr, source => source.MapFrom(o => o.ApVendors.VendorNameAr))
                 .ForMember(dest => dest.VendorEn, source => source.MapFrom(o => o.ApVendors.VendorNameEn))
                 .ForMember(dest => dest.VendorNumber, source => source.MapFrom(o => o.ApVendors.VendorNumber))
                 .ForMember(dest => dest.TotalAmount, source => source.MapFrom(o => o.ScMaintenanceQuotationDetails.Sum(x => x.Amount)))
                 ;

        }
    }
}
