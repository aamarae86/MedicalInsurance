using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonsAdditionHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [Display(Name = nameof(HrPersonsAdditionHd.AdditionNumber), ResourceType = typeof(HrPersonsAdditionHd))]
        [MaxLength(30)]
        public string AdditionNumber { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.AdditionName), ResourceType = typeof(HrPersonsAdditionHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string AdditionName { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.PeriodId), ResourceType = typeof(HrPersonsAdditionHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? PeriodId { get; set; }
        [Display(Name = nameof(HrPersonsAdditionHd.StatusLkpId), ResourceType = typeof(HrPersonsAdditionHd))]
        public long? StatusLkpId { get; set; }
        public string Status { get; set; }

        public GlPeriodsDetailsVM GlPeriodsDetails { get; set; }

        public FndLookupValuesVM FndLookupValuesHrPersonsAdditionHdStatusLkp { get; set; }

        public string PersonsAdditionTrStr { get; set; }

        public ICollection<HrPersonsAdditionTrVM> PersonsAdditionTr => string.IsNullOrEmpty(PersonsAdditionTrStr) ?
                new List<HrPersonsAdditionTrVM>() : Helper<List<HrPersonsAdditionTrVM>>.Convert(PersonsAdditionTrStr);
    }
}