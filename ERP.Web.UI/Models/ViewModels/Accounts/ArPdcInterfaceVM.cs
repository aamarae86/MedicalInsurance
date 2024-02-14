using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArPdcInterfaceVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(ArPdcInterface.SourceCode), ResourceType = typeof(ArPdcInterface))]
        public long? SourceCodeLkpId { get; set; }

        [Display(Name = nameof(ArPdcInterface.RegestrationNumber), ResourceType = typeof(ArPdcInterface))]
        public long? SourceId { get; set; }

        [Display(Name = nameof(ArPdcInterface.BondNo), ResourceType = typeof(ArPdcInterface))]
        public string SourceNumber { get; set; }

        [Display(Name = nameof(ArPdcInterface.Status), ResourceType = typeof(ArPdcInterface))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ArPdcInterface.Amount), ResourceType = typeof(ArPdcInterface))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(ArPdcInterface.CheckNumber), ResourceType = typeof(ArPdcInterface))]
        public string CheckNumber { get; set; }

        [Display(Name = nameof(ArPdcInterface.MaturityDate), ResourceType = typeof(ArPdcInterface))]
        public string MaturityDate { get; set; }

        [Display(Name = nameof(ArPdcInterface.BankAccount), ResourceType = typeof(ArPdcInterface))]
        public long? BankAccountId { get; set; }

        [Display(Name = nameof(ArPdcInterface.Notes), ResourceType = typeof(ArPdcInterface))]
        public string Notes { get; set; }

        [Display(Name = nameof(ArPdcInterface.Customer), ResourceType = typeof(ArPdcInterface))]
        public long? CustomerId { get; set; }

        [Display(Name = nameof(ArPdcInterface.BankLkp), ResourceType = typeof(ArPdcInterface))]
        public long? BankLkpId { get; set; }

        public FndLookupValuesVM FndLookupValuesSourceCodeLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesStatusLkp { get; set; }

        public FndLookupValuesVM FndLookupValuesBankLkp { get; set; }

        public ApBankAccountsVM ApBankAccounts { get; set; }

        public ApBankAccountsVM DepositApBankAccounts { get; set; }

        public ArCustomersVM ArCustomers { get; set; }

        [Display(Name = nameof(ArPdcInterface.DepositBankAccountId), ResourceType = typeof(ArPdcInterface))]
        public long? DepositBankAccountId { get; set; }

        [Display(Name = nameof(ArPdcInterface.FromDate), ResourceType = typeof(ArPdcInterface))]
        public string FromDate { get; set; }

        [Display(Name = nameof(ArPdcInterface.ToDate), ResourceType = typeof(ArPdcInterface))]
        public string ToDate { get; set; }

        public decimal? TotalAmount { get; set; }
    }
}