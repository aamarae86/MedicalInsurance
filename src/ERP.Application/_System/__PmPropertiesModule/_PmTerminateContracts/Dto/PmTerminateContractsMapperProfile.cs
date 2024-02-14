using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    public class PmTerminateContractsMapperProfile : Profile
    {
        public PmTerminateContractsMapperProfile()
        {
            CreateMap<PmTerminateContracts, PmTerminateContractsDto>()
               .ForMember(dest => dest.TerminationDate, source => source.MapFrom(o => o.TerminationDate.HasValue ? o.TerminationDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               ;

            //CreateMap<PmTerminateContracts, PmTerminateContractsDto>()
            //  .ForMember(dest => dest.PmContract.ContractStartDate, source => source.MapFrom(o => o.PmContract.ContractStartDate.ToString(Formatters.DateFormat)))
            //  .ForMember(dest => dest.PmContract.ContractEndDate, source => source.MapFrom(o => o.PmContract.ContractEndDate.ToString(Formatters.DateFormat)))
            //  .ForMember(dest => dest.PmContract.ContractEndDatePrint, source => source.MapFrom(o => o.PmContract.ContractEndDatePrint.ToString(Formatters.DateFormat)))
            //  .ReverseMap()
            //  ;

            CreateMap<CreatePmTerminateContractsDto, PmTerminateContracts>()
               .ForMember(dest => dest.TerminationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TerminationDate)))
               ;

            CreateMap<PmTerminateContractsEditDto, PmTerminateContracts>()
               .ForMember(dest => dest.TerminationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TerminationDate)))
               ;
        }
    }
}
