using AutoMapper;
using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using ERP.Helpers.Core;

namespace ERP._System.__ReportsPms.Dto
{
    public class PmReportsMapperProfile : Profile
    {
        public PmReportsMapperProfile()
        {
            CreateMap<PmContractsHelperInput, PmContractsInput>()
              .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractStartDate)))
              .ForMember(dest => dest.contractEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.contractEndDate)))
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));

            CreateMap<rptArDebitCreditInputHelper, rptArDebitCreditInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));

            CreateMap<rptPmPropertiesIncomeHelperInput, rptPmPropertiesIncomeInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));

            CreateMap<rptArDebitCreditOutput, rptArDebitCreditOutputDto>()
               .ForMember(dest => dest.DocDate, source => source.MapFrom(o => o.DocDate == null ? string.Empty : o.DocDate.ToString(Formatters.DateFormat)));
        }
    }
}
