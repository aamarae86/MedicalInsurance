using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApMiscPaymentLines;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    public class ArJobCardPaymentHdDetailsDto
    {
        public string PaymentDate { get; set; }
        public string PaymentNumber { get; set; }

        public string TransactionDate { get; set; }
        public string TransactionNumber { get; set; }

        public string Notes { get; set; }
        //public long? Id { get; set; }

        public string JobNumber { get; set; }
        public long? JobNumberLkpId { get; set; }
        public decimal? OriginalAmount { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }

        public long? SourceTypeLkpId { get; set; }
        public string SourceNameAr { get; set; }
        public string SourceNameEn { get; set; }

        public string Status { get; set; }

        public long? InvoiceNumberLkpId { get; set; }
        public string InvoiceNumber { get; set; }

        public long? SourceId { get; set; }

        public decimal? Amount { get; set; }
        public decimal? TaxAmount { get; set; }

        public long? TenantId { get; set; }
        public long? ArJobCardPaymentHdId { get; set; }

        public long? ApMiscLnId { get; set; }
        public long? ApInvoiceTrId { get; set; }

        public long? Id { get; set; }
        public string rowStatus { get; set; }
    }

    
    public class ArJobCardPaymentResultDto 
    {
        
        public ArJobCardPaymentTr ArJobCardPaymentTr { get; set; }
        public ArJobCardPaymentHd ArJobCardPaymentHd { get; set; }
        public ArJobCardHd ArJobCardHd { get; set; }
        public ApMiscPaymentHeaders ApMiscPaymentHeaders { get; set; }
        public ApMiscPaymentLines ApMiscPaymentLines { get; set; }
        public ApInvoiceHd ApInvoiceHd { get; set; }
        public ApInvoiceTr ApInvoiceTr { get; set; }
        public decimal? Amount { get; set; }
    }
}
