using AutoMapper;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmContract.Dto
{
    public class PmContractMapperProfile : Profile
    {
        public PmContractMapperProfile()
        {
            CreateMap<PmContract, PmContractDto>()
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => o.ContractDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => o.ContractEndDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => o.ContractStartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractEndDatePrint, source => source.MapFrom(o => o.ContractEndDatePrint.ToString(Formatters.DateFormat)));

            CreateMap<CreatePmContractDto, PmContract>()
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)))
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractEndDate)))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractStartDate)))
               .ForMember(dest => dest.ContractEndDatePrint, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractEndDatePrint)))
               ;

            CreateMap<PmContractEditDto, PmContract>()
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)))
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractEndDate)))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractStartDate)))
               .ForMember(dest => dest.ContractEndDatePrint, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractEndDatePrint)))
               ;

            CreateMap<ModelForAjaxCall, PmContract>()
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractEndDate)))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractStartDate)))
               ;

            CreateMap<PmContract, ModelForAjaxCall>()
               .ForMember(dest => dest.ContractEndDate, source => source.MapFrom(o => o.ContractEndDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractStartDate, source => source.MapFrom(o => o.ContractStartDate.ToString(Formatters.DateFormat)))
               ;

            CreateMap<PmContractPayments, PmContractPaymentsDto>()
              .ForMember(dest => dest.PaymentDate, source => source.MapFrom(o => o.PaymentDate.ToString(Formatters.DateFormat)))
              ;

            CreateMap<PmContractPaymentsDto, PmContractPayments>()
              .ForMember(dest => dest.PaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PaymentDate)))
              ;

        }
    }
}
