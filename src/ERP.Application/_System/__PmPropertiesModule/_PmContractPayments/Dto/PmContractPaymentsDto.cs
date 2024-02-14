using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmContractPayments.Dto
{
    [AutoMap(typeof(PmContractPayments))]
    public class PmContractPaymentsDto : EntityDto<long>, IDetailRowStatus
    {
        public string CheckNumber { get;  set; }

        public long PmContractId { get;  set; }

        public decimal PaymentNo { get;  set; }

        public decimal Amount { get;  set; }

        public string PaymentDate { get;  set; }

        public string MaturityDate { get;  set; }

        [MaxLength(4000)]
        public string Comments { get;  set; }

        public long PaymentTypeLkpId { get;  set; }

        public string PaymentTypeLkp { get;  set; }

        public long PaymentSourceLkpId { get;  set; }

        public string PaymentSourceLkp { get;  set; }

        public long? BankLkpId { get;  set; }

        public string BankLkp { get;  set; }

        public string rowStatus { get; set; }
    }
}
