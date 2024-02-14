using ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.AidModule;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.AidModule
{
    public class ScMaintenanceTechnicalReportVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalRequestNumber), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalRequestNumber { get; set; }

        [Display(Name = nameof(ScMaintenanceQuotations.PortalUserName), ResourceType = typeof(ScMaintenanceQuotations))]
        public string PortalUserName { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(ScMaintenanceTechnicalReport.TechnicalReportNumber), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public string TechnicalReportNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(ScMaintenanceTechnicalReport.TechnicalReportDate), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public string TechnicalReportDate { get; set; }

        [Display(Name = nameof(ScMaintenanceTechnicalReport.StatusLkpId), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public long? StatusLkpId { get; set; } = 940;
        public FndLookupValuesVM FndStatusLkp { get; set; }
        public string Status => ScCommittee.NewStatus;

        [Display(Name = nameof(ScMaintenanceTechnicalReport.PortalRequestId), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public long? PortalRequestId { get; set; }
        public ScPortalRequestsVM PortalRequest { get; set; }

        [Display(Name = nameof(ScMaintenanceTechnicalReport.Details_PortalUser_Name), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public string Details_PortalUser_Name { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceTechnicalReport.Notes), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public string Notes { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ScMaintenanceTechnicalReport.DetailItemDescription), ResourceType = typeof(ScMaintenanceTechnicalReport))]
        public string DetailItemDescription { get; set; }

        public string ScMaintenanceTechnicalReportDetailListStr { get; set; }

        public string AttachmentsListStr { get; set; }

        public long? ScCommitteeDetailId { get; set; }

        public List<ScMaintenanceTechnicalReportDetailDto> ListOfDetails => string.IsNullOrEmpty(ScMaintenanceTechnicalReportDetailListStr) ?
           new List<ScMaintenanceTechnicalReportDetailDto>() : Helper<List<ScMaintenanceTechnicalReportDetailDto>>.Convert(ScMaintenanceTechnicalReportDetailListStr);

        public List<ScMaintenanceTechnicalReportAttachmentsDto> ListOfAttachs => string.IsNullOrEmpty(AttachmentsListStr) ?
           new List<ScMaintenanceTechnicalReportAttachmentsDto>() : Helper<List<ScMaintenanceTechnicalReportAttachmentsDto>>.Convert(AttachmentsListStr);
    }
}