using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    [AutoMap(typeof(ApPaymentsTransactions))]
    public class ApPaymentsTransactionsCreateDto
    {
        [MaxLength(30)]
        public string PaymentNumber { get; set; }

        [MaxLength(30)]
        public string CheckNumber { get; set; }

        public string PaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public string Notes { get; set; }

        public decimal PaymentAmount { get; set; }

        public bool AccPayeeOnly { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ApPaymentsTransactions);

        public long PaymentTypeLkpId { get; set; }

        public long? BankAccountId { get; set; }

        public long VendorId { get; set; }

    }
}
