using Abp.Domain.Entities;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonVacationsVM : BasePostAuditedVM<long>
    {
        [MaxLength(30)]
        [Display(Name = nameof(HrPersonVacations.OperationNumber), ResourceType = typeof(HrPersonVacations))]
        public string OperationNumber { get; set; }

        [Display(Name = nameof(HrPersonVacations.VacationBalance), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal VacationBalance { get; set; }

        [Display(Name = nameof(HrPersonVacations.OperationDate), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationDate { get; set; }

        [Display(Name = nameof(HrPersonVacations.StartDate), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StartDate { get; set; }

        [Display(Name = nameof(HrPersonVacations.EndDate), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string EndDate { get; set; }

        [Display(Name = nameof(HrPersonVacations.StatusLkpId), ResourceType = typeof(HrPersonVacations))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(HrPersonVacations.HrVacationsTypeId), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long HrVacationsTypeId { get; set; }

        [Display(Name = nameof(HrPersonVacations.HrPersonId), ResourceType = typeof(HrPersonVacations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long HrPersonId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(HrPersonVacations.Notes), ResourceType = typeof(HrPersonVacations))]
        public string Notes { get; set; }

        [Display(Name = nameof(HrPersonVacations.NoOfDays), ResourceType = typeof(HrPersonVacations))]
        public int NoOfDays { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public HrAbsencesTypesVM HrVacationsTypes { get; set; }

        public HrPersonsVM HrPersons { get; set; }
    }
}