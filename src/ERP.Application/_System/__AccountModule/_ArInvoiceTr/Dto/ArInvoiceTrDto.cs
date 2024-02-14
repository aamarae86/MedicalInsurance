using AutoMapper;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ArInvoiceTr.Dto
{
    [AutoMap(typeof(ArInvoiceTr))]
    public class ArInvoiceTrDto : CodeComUtility, IDetailRowStatus
    {
        public long Id { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public long? AccountId { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TaxPercent { get; set; }

        public long? ArInvoiceHdId { get; set; }

        public string rowStatus { get; set; }
    }
}
