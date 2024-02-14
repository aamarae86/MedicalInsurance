using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmContractUnitDetailsVM : Abp.Domain.Entities.Entity<long>
    {
        [Display(Name = nameof(PmContract.PropertiesUnitId), ResourceType = typeof(PmContract))]
        public long PropertiesUnitId { get;  set; }
        public string PropertiesUnit { get;  set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PmContract.Notes), ResourceType = typeof(PmContract))]
        public string Notes2 { get;  set; }

        [Display(Name = nameof(PmContract.RentAmount), ResourceType = typeof(PmContract))]
        public decimal Amount { get; set; }

        [Display(Name = nameof(PmContract.AreaSize), ResourceType = typeof(PmContract))]
        public decimal AreaSize { get; set; }
    }
}