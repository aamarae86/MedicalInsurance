using AutoMapper;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    public class ArInvoiceSettlementHdMapperProfile : Profile
    {
        public ArInvoiceSettlementHdMapperProfile()
        {
            CreateMap<ArInvoiceSettlementHd, ArInvoiceSettlementHdDto>()
               .ForMember(dest => dest.SettlementDate, source => source.MapFrom(o => o.SettlementDate == null ? string.Empty : o.SettlementDate.ToString(Formatters.DateFormat)))
               .ReverseMap()
               .ForMember(dest => dest.ArInvoiceSettlementCr, source => source.Ignore())
               .ForMember(dest => dest.ArInvoiceSettlementDr, source => source.Ignore());


            CreateMap<ArInvoiceSettlementHdCreateDto, ArInvoiceSettlementHd>()
               .ForMember(dest => dest.SettlementDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.SettlementDate)))
               .ForMember(dest => dest.ArInvoiceSettlementCr, source => source.Ignore())
               .ForMember(dest => dest.ArInvoiceSettlementDr, source => source.Ignore());


            CreateMap<ArInvoiceSettlementHdEditDto, ArInvoiceSettlementHd>()
               .ForMember(dest => dest.SettlementDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.SettlementDate)))
               .ForMember(dest => dest.ArInvoiceSettlementCr, source => source.Ignore())
               .ForMember(dest => dest.ArInvoiceSettlementDr, source => source.Ignore());


            CreateMap<ArInvoiceSettlementCrDto, ArInvoiceSettlementCr>()
              .ForMember(dest => dest.Id, source => source.MapFrom(o => o.Id))
             .ReverseMap();

            CreateMap<ArInvoiceSettlementCr, ArInvoiceSettlementCrDto>()
             .ForMember(dest => dest.Id, source => source.MapFrom(o => o.Id))
            .ReverseMap();


            CreateMap<ArInvoiceSettlementDrDto, ArInvoiceSettlementDr>()
             .ForMember(dest => dest.Id, source => source.MapFrom(o => o.Id))
            .ReverseMap();

            CreateMap<ArInvoiceSettlementDr, ArInvoiceSettlementDrDto>()
             .ForMember(dest => dest.Id, source => source.MapFrom(o => o.Id))
            .ReverseMap();

            
        }
    }
}
