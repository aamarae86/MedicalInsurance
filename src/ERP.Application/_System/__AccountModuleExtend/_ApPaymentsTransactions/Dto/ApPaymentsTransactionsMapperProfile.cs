using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    public class ApPaymentsTransactionsMapperProfile : Profile
    {
        public ApPaymentsTransactionsMapperProfile()
        {
            CreateMap<ApPaymentsTransactions, ApPaymentsTransactionsDto>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.HasValue ? o.MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty))
              .ForMember(dest => dest.PaymentDate, source => source.MapFrom(o => o.PaymentDate.ToString(Formatters.DateFormat)));

            CreateMap<ApPaymentsTransactionsCreateDto, ApPaymentsTransactions>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
               .ForMember(dest => dest.PaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PaymentDate)));

            CreateMap<ApPaymentsTransactionsEditDto, ApPaymentsTransactions>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
               .ForMember(dest => dest.PaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PaymentDate)));
        }
    }
}
