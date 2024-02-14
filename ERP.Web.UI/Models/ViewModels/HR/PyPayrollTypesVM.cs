using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class PyPayrollTypesVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(200)]
        [Display(Name = nameof(PyPayrollTypes.PyPayrollTypeName), ResourceType = typeof(PyPayrollTypes))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PyPayrollTypeName { get; set; }

        [Display(Name = nameof(PyPayrollTypes.PayrollTypeNumber), ResourceType = typeof(PyPayrollTypes))]
        public string PayrollTypeNumber { get; set; }
    }
}