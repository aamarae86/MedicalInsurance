using Abp.AutoMapper;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    [AutoMap(typeof(ApPaymentsTransactions))]
    public class ApPaymentsTransactionsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string PaymentNumber { get; set; }

        public string CheckNumber { get; set; }

        public string PaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public string Notes { get; set; }

        public decimal PaymentAmount { get; set; }

        public bool AccPayeeOnly { get; set; }

        public long StatusLkpId { get; set; }

        public long PaymentTypeLkpId { get; set; }

        public long? BankAccountId { get; set; }

        public long VendorId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndPaymentTypeLkp { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public ApVendorsDto ApVendors { get; set; }
    }
}
