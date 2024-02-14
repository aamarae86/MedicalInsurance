using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArInvoiceTr.Dto;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArInvoiceHd.Dto
{
    [AutoMap(typeof(ArInvoiceHd))]
    public class ArInvoiceHdEditDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string HdDate { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public int? CurrancyId { get; set; }

        public decimal? CurrancyRate { get; set; }

        public long? ArCustomerId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public virtual ICollection<ArInvoiceTrDto> ArInvoiceTr { get; set; }

        public List<ArInvoiceTrDto> ArInvoiceTrList { get; set; }
    }
}
