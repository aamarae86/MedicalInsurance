using ERP._System._FndLookupValues;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.PmPropertiesModule;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.HR;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class FmEngineersVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(30)]
        [Display(Name = nameof(FmEngineers.EngineerNumber), ResourceType = typeof(FmEngineers))]
        public string EngineerNumber { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(FmEngineers.EngineerName), ResourceType = typeof(FmEngineers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string EngineerName { get; set; }

        [Display(Name = nameof(FmEngineers.StatusLkpId), ResourceType = typeof(FmEngineers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(FmEngineers.Comments), ResourceType = typeof(FmEngineers))]
        public string Comments { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(FmEngineers.Mobile1), ResourceType = typeof(FmEngineers))]
        public string Mobile1 { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(FmEngineers.Mobile2), ResourceType = typeof(FmEngineers))]
        public string Mobile2 { get; set; }

        [Display(Name = nameof(FmEngineers.HireDate), ResourceType = typeof(FmEngineers))]
        public string HireDate { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.EmployeeNumber), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public long? HrPersonsId { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.FirstName), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string EmployeeName { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.BirthDate), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string BirthDate { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.GenderLkpId), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string GenderAr { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.GenderLkpId), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string GenderEn { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.NationalityLkpId), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string NationalityAr { get; set; }

        [Display(Name = nameof(ResourcePack.HR.HrPersons.NationalityLkpId), ResourceType = typeof(ResourcePack.HR.HrPersons))]
        public string NationalityEn { get; set; }

        public string FndStatusLkpNameAr { get; set; }

        public string FndStatusLkpNameEn { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }
        
        public HrPersonsVM HrPersons { get; set; }
    }
}