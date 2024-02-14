using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision
{
    public class ScPRMgrDecisionElectronicAid : AuditedEntity<long>, IMustHaveTenant
    {
        public long ElectronicTypeLkpId { get; protected set; }

        public long ScPortalRequestMgrDecisionId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Amount { get; protected set; }

        [ForeignKey(nameof(ScPortalRequestMgrDecisionId))]
        public ScPortalRequestMgrDecision ScPortalRequestMgrDecision { get; protected set; }

        [ForeignKey(nameof(ElectronicTypeLkpId))]
        public FndLookupValues FndElectronicTypeLkp { get; protected set; }

        public int TenantId { get; set; }
    }
}
