using AutoMapper;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceTr.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    public class ArJobCardPaymentHdMapperProfile : Profile
    {
        public ArJobCardPaymentHdMapperProfile()
        {
            CreateMap<ArJobCardPaymentHdDto, ArJobCardPaymentHd>()
                .ForMember(dest => dest.TransactionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TransactionDate)));

            CreateMap<ArJobCardPaymentHd, ArJobCardPaymentHdDto>()
                    .ForMember(dest => dest.ArCustomers, src => src.MapFrom(o => o.ArJobCardHd.ArCustomers))
                    .ForMember(dest => dest.TransactionDate, source => source.MapFrom(o => (o.TransactionDate != null) ? o.TransactionDate.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<ArJobCardPaymentTrDto, ArJobCardPaymentTr>()
                .ForMember(dest => dest.ArJobCardPaymentHdId, src => src.MapFrom(o => o.ArJobCardPaymentHdId));


            CreateMap<ArJobCardPaymentHdCreateDto, ArJobCardPaymentHd>()
                .ForMember(dest => dest.TransactionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TransactionDate)));
               // .ForMember(dest => dest.ArJobCardHdId, so);

            CreateMap<ArJobCardPaymentHdEditDto, ArJobCardPaymentHd>()
                .ForMember(dest => dest.TransactionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TransactionDate)));

            CreateMap<ArJobCardPaymentHdDetailsDto, ArJobCardPaymentHdDetailsDto>();

            CreateMap<ArJobCardPaymentResultDto, ArJobCardPaymentHdDetailsDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(o => o.ArJobCardPaymentTr.Id))
                .ForMember(dest => dest.PaymentNumber, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId == 11570 ? o.ApInvoiceHd.HdInvNo : o.ApMiscPaymentHeaders.PaymentNumber))
                .ForMember(dest => dest.PaymentDate, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId == 11570 ? o.ApInvoiceHd.HdDate.ToString("dd/MM/yyyy") : o.ApMiscPaymentHeaders.MiscPaymentDate.Value.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.InvoiceNumber, src => src.MapFrom(o => o.ApMiscPaymentHeaders != null ? o.ApMiscPaymentHeaders.PaymentNumber : o.ApInvoiceHd.HdInvNo))
                .ForMember(dest => dest.InvoiceNumberLkpId, src => src.MapFrom(o => o.ApMiscPaymentHeaders != null ? o.ApMiscPaymentHeaders.Id : o.ApInvoiceHd.Id))
                .ForMember(dest => dest.JobNumber, src => src.MapFrom(o => o.ArJobCardHd.JobNumber))
                .ForMember(dest => dest.JobNumberLkpId, src => src.MapFrom(o => o.ArJobCardHd.Id))
                .ForMember(dest => dest.OriginalAmount, src => src.MapFrom(o => o.ArJobCardHd.OriginalAmount))
                .ForMember(dest => dest.CustomerNameEn, src => src.MapFrom(o => o.ArJobCardHd.ArCustomers.CustomerNameEn))
                .ForMember(dest => dest.CustomerNameAr, src => src.MapFrom(o => o.ArJobCardHd.ArCustomers.CustomerNameAr))
                .ForMember(dest => dest.SourceId, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceId))
                .ForMember(dest => dest.Amount, src => src.MapFrom(o => o.Amount))
                .ForPath(dest => dest.Status, src => src.MapFrom(o => _app.Reqlanguage == "ar-EG" ? o.ArJobCardPaymentTr.ArJobCardPaymentHd.FndJobCardPaymenStatusLkp.NameAr : o.ArJobCardPaymentTr.ArJobCardPaymentHd.FndJobCardPaymenStatusLkp.NameEn))
                .ForPath(dest => dest.TransactionNumber, src => src.MapFrom(o => o.ArJobCardPaymentTr.ArJobCardPaymentHd.TransactionNumber))
                .ForPath(dest => dest.TransactionDate, src => src.MapFrom(o => o.ArJobCardPaymentTr.ArJobCardPaymentHd.TransactionDate.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Notes, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId == 11570 ? o.ApInvoiceHd.Comments : o.ApMiscPaymentHeaders.Notes))
                .ForPath(dest => dest.SourceNameEn, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId == 11570 ? "Invoices" : "Misc Payment"))               
                .ForPath(dest => dest.SourceNameAr, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId == 11570 ? "فواتير" : "سند صرف عام"))
                .ForMember(dest => dest.SourceTypeLkpId, src => src.MapFrom(o => o.ArJobCardPaymentTr.SourceTypeLkpId));

        }
    }
}
