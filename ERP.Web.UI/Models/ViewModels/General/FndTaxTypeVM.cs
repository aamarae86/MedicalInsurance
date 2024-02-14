using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.General
{
    public class FndTaxTypeVM : BaseAuditedEntityVM<long>
    {
        [MaxLength(30)]
        public string TaxTypeNumber { get;  set; }
        [MaxLength(200)]
     
        public string TaxNameAr { get;  set; }
      
        [MaxLength(200)]
        public string TaxNameEn { get;  set; }
    
        public decimal Percentage { get;  set; }

    }
}