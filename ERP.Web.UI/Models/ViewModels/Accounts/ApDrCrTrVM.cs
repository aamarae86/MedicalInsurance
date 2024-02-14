
using ERP._System._FndTaxType;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Warehouses;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ApDrCrTrVM : CodeComUtility, IDetailRowStatus
    {
        public int Index { get; set; }

        public long? Id { get; set; }

        public long? AccountId { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public decimal? Amount { get; set; }

        public decimal? Tax { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Warehouses.IvItems.FndTaxtypeId), ResourceType = typeof(IvItems))]
        public long? FndTaxtypeId { get; set; }
        public FndTaxTypeDto FndTaxType { get; set; }
        public long? ArDrCrHdId { get; set; }

        public string rowStatus { get; set; }
    }
}