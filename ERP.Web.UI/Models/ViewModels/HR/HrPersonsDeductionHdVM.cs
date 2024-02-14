using ERP._System.__HR._HrPersonsDeduction.Dto;
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
    public class HrPersonsDeductionHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        public string Status { get; set; }

        [Display(Name = nameof(HrPersonsDeductionHd.StatusLkpId), ResourceType = typeof(HrPersonsDeductionHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(HrPersonsDeductionHd.DeductionNumber), ResourceType = typeof(HrPersonsDeductionHd))]
        public string DeductionNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrPersonsDeductionHd.DeductionName), ResourceType = typeof(HrPersonsDeductionHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string DeductionName { get; set; }

        [Display(Name = nameof(HrPersonsDeductionHd.PeriodId), ResourceType = typeof(HrPersonsDeductionHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PeriodId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public GlPeriodsDetailsVM Periods { get; set; }

        #region details

        [Display(Name = nameof(HrPersonsDeductionHd.HrPersonId), ResourceType = typeof(HrPersonsDeductionHd))]
        public long HrPersonId { get; set; }

        [Display(Name = nameof(HrPersonsDeductionHd.DeductionTypeLkpId), ResourceType = typeof(HrPersonsDeductionHd))]
        public long DeductionTypeLkpId { get; set; }

        [Display(Name = nameof(HrPersonsDeductionHd.Amount), ResourceType = typeof(HrPersonsDeductionHd))]
        public decimal Amount { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrPersonsDeductionHd.Notes), ResourceType = typeof(HrPersonsDeductionHd))]
        public string Notes { get; set; }

        public string PersonsDeductionDetailsListStr { get; set; }

        public ICollection<HrPersonsDeductionTrDto> PersonsDeductionDetails => string.IsNullOrEmpty(PersonsDeductionDetailsListStr) ?
                new List<HrPersonsDeductionTrDto>() : Helper<List<HrPersonsDeductionTrDto>>.Convert(PersonsDeductionDetailsListStr);

        #endregion
    }
}