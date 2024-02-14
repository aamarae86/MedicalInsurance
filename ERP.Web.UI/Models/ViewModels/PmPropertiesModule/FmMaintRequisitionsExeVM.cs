using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class FmMaintRequisitionsExeVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.StatusLkpId), ResourceType = typeof(FmMaintRequisitionsExe))]
        public long StatusLkpId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.ExecuteTypeLkpId), ResourceType = typeof(FmMaintRequisitionsExe))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ExecuteTypeLkpId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.EngineerNumber), ResourceType = typeof(FmMaintRequisitionsExe))]
        public long? EngineerId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.EngineerId), ResourceType = typeof(FmMaintRequisitionsExe))]
        public string EngineerName { get; set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.FmContractsId), ResourceType = typeof(FmMaintRequisitionsExe))]
        public long? FmContractsId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.FmContractVisitsId), ResourceType = typeof(FmMaintRequisitionsExe))]
        public long? FmContractVisitsId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.FmMaintRequisitionsHdrId), ResourceType = typeof(FmMaintRequisitionsExe))]
        public long? FmMaintRequisitionsHdrId { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.ExecuteDate), ResourceType = typeof(FmMaintRequisitionsExe))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ExecuteDate { get;  set; }

        [Display(Name = nameof(FmMaintRequisitionsExe.ExecuteTime), ResourceType = typeof(FmMaintRequisitionsExe))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ExecuteTime { get;  set; }

        [MaxLength(4000)]
        [Display(Name = nameof(FmMaintRequisitionsExe.Comments), ResourceType = typeof(FmMaintRequisitionsExe))]
        public string Comments { get;  set; }

        public string FmContractVisitNumber { get; set; }

        public FndLookupValuesVM FndStatusLkp { get;  set; }

        public FndLookupValuesVM FndExecuteTypeLkp { get;  set; }

        public FmEngineersVM FmEngineers { get;  set; }

        public FmContractsVM FmContracts { get;  set; }

        public FmMaintRequisitionsHdrVM FmMaintRequisitionsHdr { get;  set; }
    }
}