using ERP._System.__PmPropertiesModule._PmContractAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails.Dto;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmContractVM : BasePostAuditedVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        [Display(Name = nameof(PmContract.PropertyId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PropertyId { get; set; }

        [Display(Name = nameof(PmContract.ContractNumber), ResourceType = typeof(PmContract))]
        public string ContractNumber { get; set; }

        public string Status { get; set; }

        [Display(Name = nameof(PmContract.ContractDate), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ContractDate { get; set; }

        [Display(Name = nameof(PmContract.ContractStartDate), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ContractStartDate { get; set; }

        [Display(Name = nameof(PmContract.ContractEndDate), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ContractEndDate { get; set; }

        [Display(Name = nameof(PmContract.ContractEndDatePrint), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ContractEndDatePrint { get; set; }

        [MaxLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMaxLength), ErrorMessageResourceType = typeof(FndUsers))]
        [MinLength(15, ErrorMessageResourceName = nameof(FndUsers.IdMinLength), ErrorMessageResourceType = typeof(FndUsers))]
        [Display(Name = nameof(PmContract.TaxNo), ResourceType = typeof(PmContract))]
        public string TaxNo { get; set; }

        [Display(Name = nameof(PmContract.TaxPercent), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal TaxPercent { get; set; }

        [Display(Name = nameof(PmContract.RentAmount), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal RentAmount { get; set; }

        [Display(Name = nameof(PmContract.AnnualRentAmount), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal AnnualRentAmount { get; set; }

        [Display(Name = nameof(PmContract.InsuranceAmount), ResourceType = typeof(PmContract))]
        public decimal? InsuranceAmount { get; set; }

        [Display(Name = nameof(PmContract.PmUnitTypeLkpId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmUnitTypeLkpId { get; set; }

        [Display(Name = nameof(PmContract.StatusLkpId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(PmContract.PmTenantId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmTenantId { get; set; }

        [Display(Name = nameof(PmContract.PmPaymentNoLkpId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmPaymentNoLkpId { get; set; }

        [Display(Name = nameof(PmContract.PmActivityLkpId), ResourceType = typeof(PmContract))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PmActivityLkpId { get; set; }

        public long? ParentContractId { get; set; }

        public long PmOwnerId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Notes), ResourceType = typeof(PmContract))]
        public string Notes { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Condition1), ResourceType = typeof(PmContract))]
        public string Condition1 { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Condition2), ResourceType = typeof(PmContract))]
        public string Condition2 { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Condition3), ResourceType = typeof(PmContract))]
        public string Condition3 { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Condition4), ResourceType = typeof(PmContract))]
        public string Condition4 { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Condition5), ResourceType = typeof(PmContract))]
        public string Condition5 { get; set; }


        [Display(Name = nameof(PmContract.PropertyNumber), ResourceType = typeof(PmContract))]
        public long PropertyNumber { get; set; }

        [Display(Name = nameof(PmContract.PmOwner), ResourceType = typeof(PmContract))]
        public string OwnerName { get; set; }

        [Display(Name = nameof(PmContract.TaxAmount), ResourceType = typeof(PmContract))]
        public decimal TaxAmount { get; set; }

        [Display(Name = nameof(PmContract.TotalOfOther), ResourceType = typeof(PmContract))]
        public decimal TotalOfOther { get; set; }

        [Display(Name = nameof(PmContract.Total), ResourceType = typeof(PmContract))]
        public decimal Total { get; set; }

        public PmContractVM Parent { get; set; }

        public PmTenantsVM PmTenants { get; set; }

        public PmPropertiesVM PmProperties { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndUnitTypeLkp { get; set; }

        public FndLookupValuesVM FndActivityLkp { get; set; }

        public FndLookupValuesVM FndPaymentNoLkp { get; set; }

        public string UnitsListStr { get; set; }
        public ICollection<PmContractUnitDetailsDto> PmContUnitDetails => string.IsNullOrEmpty(UnitsListStr) ?
               new List<PmContractUnitDetailsDto>() : Helper<List<PmContractUnitDetailsDto>>.Convert(UnitsListStr);

        public string PaymentsListStr { get; set; }
        public ICollection<PmContractPaymentsDto> PmContPayments => string.IsNullOrEmpty(PaymentsListStr) ?
               new List<PmContractPaymentsDto>() : Helper<List<PmContractPaymentsDto>>.Convert(PaymentsListStr);

        public string PaymentsOtherListStr { get; set; }
        public ICollection<PmOtherContractPaymentsDto> PmOtherContPayments => string.IsNullOrEmpty(PaymentsOtherListStr) ?
               new List<PmOtherContractPaymentsDto>() : Helper<List<PmOtherContractPaymentsDto>>.Convert(PaymentsOtherListStr);

        public string AttachmentsListStr { get; set; }
        public ICollection<PmContractAttachmentsDto> PmContAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
               new List<PmContractAttachmentsDto>() : Helper<List<PmContractAttachmentsDto>>.Convert(AttachmentsListStr);

    }
}