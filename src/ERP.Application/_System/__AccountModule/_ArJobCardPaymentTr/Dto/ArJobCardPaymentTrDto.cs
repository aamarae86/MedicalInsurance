using Abp.Application.Services.Dto;
using AutoMapper;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardPaymentTr.Dto
{
   
    [AutoMap(typeof(ArJobCardPaymentTr))]
    public class ArJobCardPaymentTrDto : EntityDto<long>, IDetailRowStatus
    {      
        public long? ArJobCardPaymentHdId   { get; set; }

        public long? SourceId { get; set; }
        public long? SourceTypeLkpId { get; set; }
        public string rowStatus { get ; set; }
    }
}
