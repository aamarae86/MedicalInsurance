using Abp.Domain.Entities;
using ERP.ResourcePack.SpGuarantees;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpCaseEditDataVM : Entity<long>
    {
        public string EncId { get; set; }

        public long SpContractDetailsId { get; set; }

        [Display(Name = nameof(SpCaseEditData.ContractNumber), ResourceType = typeof(SpCaseEditData))]
        public string ContractNumber { get; set; }

        [Display(Name = nameof(SpCaseEditData.BeneficentName), ResourceType = typeof(SpCaseEditData))]
        public string BeneficentName { get; set; }

        [Display(Name = nameof(SpCaseEditData.BeneficentNumber), ResourceType = typeof(SpCaseEditData))]
        public string BeneficentNumber { get; set; }

        [Display(Name = nameof(SpCaseEditData.CaseNumber), ResourceType = typeof(SpCaseEditData))]
        public string CaseNumber { get; set; }

        [Display(Name = nameof(SpCaseEditData.CaseName), ResourceType = typeof(SpCaseEditData))]
        public string CaseName { get; set; }

        public string SponsorLkpNameAr { get; set; }

        public string SponsorLkpNameEn { get; set; }

        [Display(Name = nameof(SpCaseEditData.BeneficentName), ResourceType = typeof(SpCaseEditData))]
        public long BeneficentId { get; set; }

        [Display(Name = nameof(SpCaseEditData.CaseName), ResourceType = typeof(SpCaseEditData))]
        public long CaseId { get; set; }


        [Display(Name = nameof(SpCaseEditData.BankLkpId), ResourceType = typeof(SpCaseEditData))]
        public long? BankLkpId { get; set; }
        public string BeneficentBankAr { get; set; }
        public string BeneficentBankEn { get; set; }
        public string AccountOwner { get; set; }
        public string AccountNumber { get; set; }
        public string NameFor { get; set; }
        public string Amount { get; set; }

        [Display(Name = nameof(SpCaseEditData.Notes), ResourceType = typeof(SpCaseEditData))]
        public string Notes { get; set; }
    }
}