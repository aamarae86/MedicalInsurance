using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ArInvoiceHd.Dto
{
    [AutoMap(typeof(ArInvoiceHd))]
    public class ArInvoiceHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string HdInvoiceNo { get; set; }

        public string HdDate { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public long? StatusLkpId { get; set; }

        public int? CurrancyId { get; set; }

        public decimal? CurrancyRate { get; set; } 
        public decimal? TotalAmount { get; set; }

        public long? ArCustomerId { get; set; }

        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public FndLookupValuesDto FndLookupValuesArInvoiceHdStatusLkp { get; set; }
     
        public FndLookupValuesDto FndLookupValuesArInvoiceHdSourceLkp { get; set; }
      
        public CurrencyDto Currency { get; set; }
        
        public ArCustomersDto ArCustomers { get; set; }
    }
}
