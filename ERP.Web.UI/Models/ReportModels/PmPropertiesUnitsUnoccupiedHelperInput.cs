using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class PmPropertiesUnitsUnoccupiedHelperInput
    {
        public long? PropertyId { get; set; }
        public string PropertyIdtxt { get; set; }
        public long? OwnerId { get; set; }
        public string OwnerIdtxt { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public string PmUnitTypeLkpIdtxt { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&PropertyId={PropertyId}&OwnerId={OwnerId}&PmUnitTypeLkpId={PmUnitTypeLkpId}&TenantId={TenantId}";
        }
    }
}