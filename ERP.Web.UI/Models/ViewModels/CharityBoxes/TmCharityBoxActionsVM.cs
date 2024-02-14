using ERP._System.__CharityBoxes._TmCharityBoxActions.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxActionsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.ActionsDate), ResourceType = typeof(TmCharityBoxActions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ActionsDate { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.ActionsNumber), ResourceType = typeof(TmCharityBoxActions))]
        public string ActionsNumber { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.TmSupervisorId), ResourceType = typeof(TmCharityBoxActions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long TmSupervisorId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(TmCharityBoxActions.Notes), ResourceType = typeof(TmCharityBoxActions))]
        public string Notes { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.StatusLkpId), ResourceType = typeof(TmCharityBoxActions))]
        public string Status { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.StatusLkpId), ResourceType = typeof(TmCharityBoxActions))]
        public long StatusLkpId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public TmSupervisorsVM TmSupervisors { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.ActionLkpId), ResourceType = typeof(TmCharityBoxActions))]
        public long ActionLkpId { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.TmLocationSubId), ResourceType = typeof(TmCharityBoxActions))]
        public long TmLocationSubId { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.OldCharityBoxid), ResourceType = typeof(TmCharityBoxActions))]
        public long? OldCharityBoxid { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.NewCharityBoxId), ResourceType = typeof(TmCharityBoxActions))]
        public long? NewCharityBoxId { get; set; }

        public string BoxActionsDetailsListStr { get; set; }

        public ICollection<TmCharityBoxActionDetailsDto> BoxActionsDetails => string.IsNullOrEmpty(BoxActionsDetailsListStr) ?
             new List<TmCharityBoxActionDetailsDto>() : Helper<List<TmCharityBoxActionDetailsDto>>.Convert(BoxActionsDetailsListStr);
    }
}