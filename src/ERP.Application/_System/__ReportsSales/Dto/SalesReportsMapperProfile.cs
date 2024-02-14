using AutoMapper;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsSales.Input;
using ERP.Helpers.Core;

namespace ERP._System.__ReportsSales.Dto
{
    public class SalesReportsMapperProfile : Profile
    {
        public SalesReportsMapperProfile()
        {
            CreateMap<ArJobCardHelperInput, ArJobCardInput>()
              .ForMember(dest => dest.ArCustomerId, source => source.MapFrom(o => o.ArCustomerLkpId ))
              .ForMember(dest => dest.JobNumber, source => source.MapFrom(o => o.JobNumberLkpIdtxt))
              .ForMember(dest => dest.StatusLkpId, source => source.MapFrom(o => o.StatusLkpId))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));


            CreateMap<ArJobCardDetailsHelperInput, ArJobCardDetailsInput>()
              .ForMember(dest => dest.ArCustomerId, source => source.MapFrom(o => o.ArCustomerLkpId))
              .ForMember(dest => dest.JobNumber, source => source.MapFrom(o => o.JobNumberLkpIdtxt))
              .ForMember(dest => dest.StatusLkpId, source => source.MapFrom(o => o.StatusLkpId))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));
        }
    }
}
