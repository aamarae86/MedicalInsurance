using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    [AutoMap(typeof(ArJobCardPaymentHd))]
    public class ArJobCardPaymentHdCreateDto
    {
        public string TransactionDate { get; set; }

        public string TransactionNumber { get; set; }

        public long? StatusLkpId { get; set; }
        
        public long? ArJobCardHdId { get; set; }

        public List<ArJobCardPaymentTrDto> ArJobCardPaymentTrList { get; set; }

    }
}
