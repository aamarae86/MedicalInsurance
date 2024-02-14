using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    [AutoMap(typeof(ApPaymentsTransactions))]
    public class ApPaymentsTransactionsEditDto : EntityDto<long>
    {
        public string CheckNumber { get; set; }

        public string PaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public string Notes { get; set; }

        public decimal PaymentAmount { get; set; }

        public bool AccPayeeOnly { get; set; }

        public long PaymentTypeLkpId { get; set; }

        public long? BankAccountId { get; set; }

        public long VendorId { get; set; }
    }
}
