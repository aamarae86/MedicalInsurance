using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._ArCustomers;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    [AutoMap(typeof(ArJobCardPaymentHd))]
    public class ArJobCardPaymentHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

       
        public string TransactionDate { get; set; }  
        public string TransactionNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public FndLookupValuesDto FndJobCardPaymenStatusLkp { get; set; }
        public long? ArJobCardHdId { get; set; }
        public ArJobCardHd ArJobCardHd { get; set; }
        public ArCustomers ArCustomers { get; set; }        

    }
}
