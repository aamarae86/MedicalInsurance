using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class PyPayrollOperationsVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.BankLkpId), ResourceType = typeof(PyPayrollOperations))]
        public decimal BankLkpId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.AccountNumber), ResourceType = typeof(PyPayrollOperations))]
        public decimal AccountNumber { get; set; }

        [Display(Name = nameof(PyPayrollOperations.PayrollNetValue), ResourceType = typeof(PyPayrollOperations))]
        public decimal PayrollNetValue { get; set; }

        [Display(Name = nameof(PyPayrollOperations.PayrollTotalValue), ResourceType = typeof(PyPayrollOperations))]
        public decimal PayrollTotalValue { get; set; }

        [Display(Name = nameof(Settings.StartDate), ResourceType = typeof(Settings))]
        public string StartDate { get; set; }

        [Display(Name = nameof(Settings.EndDate), ResourceType = typeof(Settings))]
        public string EndDate { get; set; }

        [Display(Name = nameof(PyPayrollOperations.OperationNumber), ResourceType = typeof(PyPayrollOperations))]
        public string OperationNumber { get; set; }

        [Display(Name = nameof(PyPayrollOperations.HrPersonNumber), ResourceType = typeof(PyPayrollOperations))]
        public string HrPersonNumber { get; set; }

        [Display(Name = nameof(PyPayrollOperations.HrPersonId), ResourceType = typeof(PyPayrollOperations))]
        public string HrPersonName { get; set; }

        [Display(Name = nameof(PyPayrollOperations.OperationDate), ResourceType = typeof(PyPayrollOperations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string OperationDate { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PyPayrollOperations.Notes), ResourceType = typeof(PyPayrollOperations))]
        public string Notes { get; set; }

        [Display(Name = nameof(PyPayrollOperations.StatusLkpId), ResourceType = typeof(PyPayrollOperations))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.PeriodId), ResourceType = typeof(PyPayrollOperations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PeriodId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.PyPayrollTypeId), ResourceType = typeof(PyPayrollOperations))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PyPayrollTypeId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.HrPersonId), ResourceType = typeof(PyPayrollOperations))]
        public long? HrPersonId { get; set; }

        [Display(Name = nameof(PyPayrollOperations.JobLkpId), ResourceType = typeof(PyPayrollOperations))]
        public long? JobLkpId { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndJobLkp { get; set; }

        public GlPeriodsDetailsVM Periods { get; set; }

        public HrPersonsVM HrPersons { get; set; }

        public PyPayrollTypesVM PyPayrollTypes { get; set; }
    }
}