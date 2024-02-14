using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScMaintenanceQuotationsVM : BasePostAuditedVM<long>, IAttachmentListJSONString
    {
        public string EncId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ScMaintenanceQuotations.QuotationNumber), ResourceType = typeof(ScMaintenanceQuotations))]
        public string QuotationNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.QuotationDate), ResourceType = typeof(ScMaintenanceQuotations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string QuotationDate { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.StatusLkpId), ResourceType = typeof(ScMaintenanceQuotations))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.ScMaintenanceTechnicalReportId), ResourceType = typeof(ScMaintenanceQuotations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ScMaintenanceTechnicalReportId { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.VendorId), ResourceType = typeof(ScMaintenanceQuotations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VendorId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceQuotations.Notes), ResourceType = typeof(ScMaintenanceQuotations))]
        public string Notes { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.ScMaintenanceTechnicalReportDetailId), ResourceType = typeof(ScMaintenanceQuotations))]
        public string MaintenanceTechnicalReportItemDescription { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.Amount), ResourceType = typeof(ScMaintenanceQuotations))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalRequestNumber), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalRequestNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalUserName), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalUserName { get; set; }

        public string AttachmentsListStr { get; set; }

        public string MaintenanceQuotationDetailsListStr { get; set; }

        public virtual ScMaintenanceTechnicalReportVM ScMaintenanceTechnicalReport { get; set; }

        public virtual FndLookupValuesVM FndStatusLkp { get; set; }

        public virtual ApVendorsVM ApVendors { get; set; }

        public virtual ICollection<ScMaintenanceQuotationDetailsDto> MaintenanceQuotationDetails => string.IsNullOrEmpty(MaintenanceQuotationDetailsListStr) ?
               new List<ScMaintenanceQuotationDetailsDto>() : Helper<List<ScMaintenanceQuotationDetailsDto>>.Convert(MaintenanceQuotationDetailsListStr);

        public virtual ICollection<ScMaintenanceQuotationAttachmentsDto> MaintenanceQuotationAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
               new List<ScMaintenanceQuotationAttachmentsDto>() : Helper<List<ScMaintenanceQuotationAttachmentsDto>>.Convert(AttachmentsListStr);

    }
}