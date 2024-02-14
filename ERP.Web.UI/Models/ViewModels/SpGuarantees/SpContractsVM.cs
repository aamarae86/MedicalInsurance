using ERP._System.__SpGuarantees._SpContracts.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.SpGuarantees;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.SpGuarantees
{
    public class SpContractsVM : BasePostAuditedVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        [Display(Name = nameof(SpContracts.ContractNumber), ResourceType = typeof(SpContracts))]
        public string ContractNumber { get; set; }

        [Display(Name = nameof(SpContracts.ContractDate), ResourceType = typeof(SpContracts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ContractDate { get; set; }

        [Display(Name = nameof(SpContracts.StatusLkpId), ResourceType = typeof(SpContracts))]
        public long StatusLkpId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(SpContracts.PaymentTypeLkpId), ResourceType = typeof(SpContracts))]
        public long? PaymentTypeLkpId { get;  set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(SpContracts.DeductedLkpId), ResourceType = typeof(SpContracts))]
        public long? DeductedLkpId { get;  set; }

        [Display(Name = nameof(SpContracts.SpBeneficentId), ResourceType = typeof(SpContracts))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long SpBeneficentId { get; set; }

        public long SpContractId { get; set; }

        [Display(Name = nameof(SpContracts.SpCaseId), ResourceType = typeof(SpContracts))]
        public long SpCaseId { get; set; }

        public string SpCase { get; set; }

        [Display(Name = nameof(SpContracts.CaseStatusLkpId), ResourceType = typeof(SpContracts))]
        public string CaseStatus { get; set; }

        public string CaseStatusLkp { get; set; }

        [Display(Name = nameof(SpContracts.StartDate), ResourceType = typeof(SpContracts))]
        public string StartDate { get; set; }

        [Display(Name = nameof(SpContracts.EndDate), ResourceType = typeof(SpContracts))]
        public string EndDate { get; set; }

        [Display(Name = nameof(SpContracts.Amount), ResourceType = typeof(SpContracts))]
        public decimal? Amount { get; set; }

        [Display(Name = nameof(SpContracts.SponsFor), ResourceType = typeof(SpContracts))]
        public string SponsFor { get; set; }

        [Display(Name = nameof(SpContracts.SponsFor), ResourceType = typeof(SpContracts))]
        public string SponsAccountFor { get; set; }

        [Display(Name = nameof(SpContracts.SpBeneficentBankId), ResourceType = typeof(SpContracts))]
        public long? SpBeneficentBankId { get; set; }

        public string SpBeneficentBank { get; set; }

        [Display(Name = nameof(SpContracts.BankLkpId), ResourceType = typeof(SpContracts))]
        public long? BankLkpId { get; set; }

        public string BankLkp { get; set; }

        [Display(Name = nameof(SpContracts.AccountNumber), ResourceType = typeof(SpContracts))]
        public string AccountNumber { get; set; }

        [Display(Name = nameof(SpContracts.AccountOwnerName), ResourceType = typeof(SpContracts))]
        public string AccountOwnerName { get; set; }

        [Display(Name = nameof(SpContracts.AttachmentName), ResourceType = typeof(SpContracts))]
        public string AttachmentName { get; set; }

        [Display(Name = nameof(SpContracts.BeneficentNumber), ResourceType = typeof(SpContracts))]
        public string BeneficentNumber { get; set; }

        [Display(Name = nameof(SpContracts.MobileNumber), ResourceType = typeof(SpContracts))]
        public string MobileNumber { get; set; }

        [Display(Name = nameof(SpContracts.SponsorCategoryLkpId), ResourceType = typeof(SpContracts))]
        public string SponsorCategory { get; set; }

        [Display(Name = nameof(SpContracts.CaseNumber), ResourceType = typeof(SpContracts))]
        public string CaseNumber { get; set; }

        [Display(Name = nameof(SpContracts.StatusLkpId), ResourceType = typeof(SpContracts))]
        public string Status { get; set; }

        public SpBeneficentVM SpBeneficent { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndPaymentTypeLkp { get; set; }

        public FndLookupValuesVM FndDeductedLkp { get; set; }

        public string AttachmentsListStr { get; set; }

        public string ContractDetailsListStr { get; set; }

        public ICollection<SpContractAttachmentsDto> ContractAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
                new List<SpContractAttachmentsDto>() :
                Helper<List<SpContractAttachmentsDto>>.Convert(AttachmentsListStr);

        public ICollection<SpContractDetailsDto> ContractDetails => string.IsNullOrEmpty(ContractDetailsListStr) ?
                new List<SpContractDetailsDto>() :
                Helper<List<SpContractDetailsDto>>.Convert(ContractDetailsListStr);
    }
}