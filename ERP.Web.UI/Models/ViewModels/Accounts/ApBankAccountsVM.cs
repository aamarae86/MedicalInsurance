using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Core;
using ERP.ResourcePack.Accounts;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApBankAccountsVM : AuditedEntity<long>, IAuditedEntityStrDates
    {
        [Display(Name = nameof(ResourcePack.Accounts.ApBanks.BankAccountNameAr), ResourceType = typeof(ApBanks))]
        public string BankAccountNameAr { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApBanks.BankAccountNameEn), ResourceType = typeof(ApBanks))]
        public string BankAccountNameEn { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApBanks.CurrencyId), ResourceType = typeof(ApBanks))]
        public int CurrencyId { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApBanks.CurrencyRate), ResourceType = typeof(ApBanks))]
        public decimal CurrencyRate { get; set; }

        public long? AccountId { get; set; }

        public long? cPdcAccountId { get; set; }

        public long? PdcCollAccountId { get; set; }

        public long? ApPdcCollAccountId { get; set; }

        public long BankId { get; set; }

        public CurrenciesVM Currency { get; set; }
        public ApBanksVM ApBanks { get; set; }

        [Display(Name = nameof(ResourcePack.Accounts.ApBanks.IsActive), ResourceType = typeof(ApBanks))]
        public bool IsAccountActive { get; set; }

        public string CreationTimeStr => this.CreationTime.ToString("yyyy/MM/dd");
            //public string DeletionTimeStr => this.DeletionTime == null ? null : this.DeletionTime.Value.ToString("yyyy/MM/dd");
        public string LastModificationTimeStr => this.LastModificationTime == null ? null : this.LastModificationTime.Value.ToString("yyyy/MM/dd");

    }
}