using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArInvoiceTr.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ArInvoiceHd.Dto
{
    [AutoMap(typeof(ArInvoiceHd))]
    public class CreateArInvoiceHdDto
    {
        [MaxLength(30)]
        public string HdInvoiceNo { get; set; }

        public string HdDate { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public long? StatusLkpId => 251;

        public int? CurrancyId { get; set; }

        public decimal? CurrancyRate { get; set; }

        public long? ArCustomerId { get; set; }

        public long? SourceLkpId => 283;

        public long? SourceId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public List<ArInvoiceTrDto> ArInvoiceTrList { get; set; }
    }
}
