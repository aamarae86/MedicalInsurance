using AutoMapper;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System._SpDtos._TaxReportData;
using ERP._System._SpDtos._TaxReportData2;
using ERP.Helpers.Core;

namespace ERP._System.__ReportsAccounts.Dto
{
    public class FaAssetListDataProfiler: Profile
    {
        public FaAssetListDataProfiler()
        {
            CreateMap<GetFaAssetListDataInputHelper, GetFaAssetListDataInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));

            
            CreateMap<GetApPdcInterfaceDataInputHelper, GetApPdcInterfaceDataInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));


            CreateMap<GetArPdcInterfaceDataInputHelper, GetArPdcInterfaceDataInput>()
             .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
             .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));

            

            CreateMap<GetTaxReportDataInputHelper, GetTaxReportDataInput>()
             .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
             .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));


            CreateMap<GetTaxReportData2InputHelper, GetTaxReportData2Input>()
             .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
             .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));


        }
    }
}
