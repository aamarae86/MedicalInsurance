using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrAbsencesTypesVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(HrAbsencesTypes.AbsencesTypeNumber), ResourceType = typeof(HrAbsencesTypes))]
        [MaxLength(30)]
        public string VacationsTypeNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(HrAbsencesTypes.AbsencesTypeName), ResourceType = typeof(HrAbsencesTypes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string VacationsTypeName { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrAbsencesTypes.AbsencesTypeDesc), ResourceType = typeof(HrAbsencesTypes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string VacationsTypeDesc { get; set; }

        [Display(Name = nameof(HrAbsencesTypes.MaximumDaysPerYear), ResourceType = typeof(HrAbsencesTypes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? MaximumDaysPerYear { get; set; }

        [Display(Name = nameof(HrAbsencesTypes.MaximumDays), ResourceType = typeof(HrAbsencesTypes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal? MaximumDays { get; set; }
    }
}