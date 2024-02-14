using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd.Dto
{
    [AutoMap(typeof(ArJobCardPaymentHd))]
    public class ArJobCardPaymentHdEditDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string TransactionDate { get; set; }

        public string TransactionNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? ArJobCardHdId { get; set; }

        public virtual ICollection<ArJobCardPaymentTrDto> ArJobCardPaymentTr { get; set; }     
       
        public ICollection<ArJobCardPaymentTrDto> ArJobCardPaymentTrList { get; set; }

    }
}
