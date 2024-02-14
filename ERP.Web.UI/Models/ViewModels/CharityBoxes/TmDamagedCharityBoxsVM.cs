using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmDamagedCharityBoxsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(Settings.FromDate), ResourceType = typeof(Settings))]
        public string FromDate { get; set; }

        [Display(Name = nameof(Settings.ToDate), ResourceType = typeof(Settings))]
        public string ToDate { get; set; }

        [Display(Name = nameof(TmDamagedCharityBoxs.DamageReason), ResourceType = typeof(TmDamagedCharityBoxs))]
        public string DamageReason { get; set; }

        [Display(Name = nameof(TmDamagedCharityBoxs.DamagedCharityBoxsDate), ResourceType = typeof(TmDamagedCharityBoxs))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string DamagedCharityBoxsDate { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(TmDamagedCharityBoxs.DamagedCharityBoxsNumber), ResourceType = typeof(TmDamagedCharityBoxs))]
        public string DamagedCharityBoxsNumber { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(TmCharityBoxActions.Notes), ResourceType = typeof(TmCharityBoxActions))]
        public string Notes { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.StatusLkpId), ResourceType = typeof(TmCharityBoxActions))]
        public string Status { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.StatusLkpId), ResourceType = typeof(TmCharityBoxActions))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(TmCharityBoxActions.TmSupervisorId), ResourceType = typeof(TmCharityBoxActions))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long TmSupervisorId { get; set; }

        public FndLookupValuesVM FndStatusLookup { get; set; }

        public TmSupervisorsVM TmSupervisors { get; set; }

        public long CharityBoxActionDetailId { get; set; }

        [Display(Name = nameof(TmCharityBoxCollect.CharityBox), ResourceType = typeof(TmCharityBoxCollect))]
        public string CharityBoxName { get; set; }

        public string DamagedCharityBoxDetailsListStr { get; set; }

        public ICollection<TmDamagedCharityBoxDetailsDto> DamagedCharityBoxDetails => string.IsNullOrEmpty(DamagedCharityBoxDetailsListStr) ?
          new List<TmDamagedCharityBoxDetailsDto>() : Helper<List<TmDamagedCharityBoxDetailsDto>>.Convert(DamagedCharityBoxDetailsListStr);
    }
}