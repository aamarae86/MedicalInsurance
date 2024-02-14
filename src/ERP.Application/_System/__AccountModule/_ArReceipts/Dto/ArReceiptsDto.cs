using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    [AutoMap(typeof(ArReceipts))]
    public class ArReceiptsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string ReceiptNumber { get; set; }

        [Required]
        public string ReceiptDate { get; set; }

        [Required]
        public long StatusLkpId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public long? ArCustomerId { get; set; }

        public ArCustomersDto ArCustomer { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [Required]
        public long BankAccountId { get; set; }

        public ApBankAccountsDto BankAccount { get; set; }

        [Required]
        public int CurrencyId { get; set; }
        public CurrencyDto Currency { get; set; }

        [Required]
        public decimal CurrencyRate { get; set; }

        public long? RemitanceBankId { get; set; }

        public ApBankAccountsDto RemitanceBank { get; set; }

        [MaxLength(30)]
        public string ManualReceiptNo { get; set; }

        public long? SourceCodeLkpId { get; set; } = 280;

        public long? SourceId { get; set; }

        public virtual ICollection<ArReceiptDetailsDto> ArReceiptDetails { get; set; }

        public virtual ICollection<ArReceiptsOnAccountDto> ArReceiptsOnAccount { get; set; }
    }
}
