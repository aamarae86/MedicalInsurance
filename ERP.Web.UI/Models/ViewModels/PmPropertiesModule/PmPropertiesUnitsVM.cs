using Abp.Domain.Entities;
using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class PmPropertiesUnitsVM : Entity<long>
    {
        [Display(Name = nameof(PmProperties.UnitNo), ResourceType = typeof(PmProperties))]
        public string UnitNo { get; set; }

        [Display(Name = nameof(PmProperties.ElectricityNumber), ResourceType = typeof(PmProperties))]
        public string ElectricityNumber { get; set; }

        [Display(Name = nameof(PmProperties.SewerageNumber), ResourceType = typeof(PmProperties))]
        public string SewerageNumber { get; set; }

        [Display(Name = nameof(PmProperties.AreaSize), ResourceType = typeof(PmProperties))]
        public decimal? AreaSize { get; set; }

        [Display(Name = nameof(PmProperties.YearlyRent), ResourceType = typeof(PmProperties))]
        public decimal YearlyRent { get; set; }

        [Display(Name = nameof(PmProperties.FloorLevel), ResourceType = typeof(PmProperties))]
        public int? FloorLevel { get; set; }

        [Display(Name = nameof(PmProperties.Description), ResourceType = typeof(PmProperties))]
        public string Description { get; set; }

        [Display(Name = nameof(PmProperties.PmUnitTypeLkpId), ResourceType = typeof(PmProperties))]
        public long PmUnitTypeLkpId { get; set; }

        public long StatusUnitsLkpId { get; set; }

        [Display(Name = nameof(PmProperties.ViewLkpId), ResourceType = typeof(PmProperties))]
        public long? ViewLkpId { get; set; }

        [Display(Name = nameof(PmProperties.FinishesLkpId), ResourceType = typeof(PmProperties))]
        public long? FinishesLkpId { get; set; }

        [Display(Name = nameof(PmProperties.StatusLkpId), ResourceType = typeof(PmProperties))]
        public string StatusUnitsLkp { get; set; }

        [Display(Name = nameof(PmProperties.PmUnitDescLkpId), ResourceType = typeof(PmProperties))]
        public long? PmUnitDescLkpId { get; set; }
    }
}