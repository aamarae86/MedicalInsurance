using Abp.Domain.Entities;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvWarehousesVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(20)]
        [Display(Name = nameof(IvWarehouses.WarehouseNumber), ResourceType = typeof(IvWarehouses))]
        public string WarehouseNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(IvWarehouses.WarehouseName), ResourceType = typeof(IvWarehouses))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string WarehouseName { get; set; }

        [Display(Name = nameof(IvWarehouses.CityLkpId), ResourceType = typeof(IvWarehouses))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CityLkpId { get; set; }

        [Display(Name = nameof(IvWarehouses.IsDefault), ResourceType = typeof(IvWarehouses))]
        public bool IsDefault { get; set; }

        [Display(Name = nameof(IvWarehouses.IsDefault), ResourceType = typeof(IvWarehouses))]
        public bool IsDefaultAlt { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(IvWarehouses.WarehouseAddress), ResourceType = typeof(IvWarehouses))]
        public string WarehouseAddress { get; set; }

        public FndLookupValuesVM FndCityLkp { get; set; }
    }
}