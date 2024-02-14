using Abp.Domain.Entities;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmPropertiesUnits
{
    public class PmPropertiesUnitsAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        public long PmPropertiesUnitstId { get; protected set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PmPropertiesUnitstId))]
        public PmPropertiesUnits PmPropertiesUnits { get; set; }

        public int TenantId { get; set; }
    }
}
