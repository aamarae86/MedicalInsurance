using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__CRM.Leads;
using System;
using ERP._System.__CRM.Deals;

namespace ERP._System.__CRM._ActivityCall
{
   public class ActivityCall : PostAuditedEntity<long>, IMustHaveTenant
    {
        public long RelatedToLkpId { get; set; }
        [ForeignKey(nameof(RelatedToLkpId))]
        public FndLookupValues RelatedToLkps { get; set; } //"CrmLeadsPersonsType"

        public long CrmLeadsPersonsId { get; set; }
        [ForeignKey(nameof(CrmLeadsPersonsId))]
        public CrmLeadsPersons CrmLeadsPersons { get; set; } //with CrmLeadsPersons

        [MaxLength(200)]
        public string Subject { get; set; }

        public long CallPurposeLkpId { get; set; }
        [ForeignKey(nameof(CallPurposeLkpId))]
        public FndLookupValues CallPurposeLkps { get; set; } //"ActivityCallPurpose"


        public long CallTypeLkpId { get; set; }
        [ForeignKey(nameof(CallTypeLkpId))]
        public FndLookupValues CallTypeLkps { get; set; } //"ActivityCallType"


        public long CallDetailsLkpId { get; set; }
        [ForeignKey(nameof(CallDetailsLkpId))]
        public FndLookupValues CallDetailsLkps { get; set; } //"ActivityCallCallDetails"

        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public long CallResultLkpId { get; set; }
        [ForeignKey(nameof(CallResultLkpId))]
        public FndLookupValues CallResultLkps { get; set; } //"ActivityCallCallResult"

        public long? CrmDealsId { get; set; }
        [ForeignKey(nameof(CrmDealsId))]
        public CrmDeals CrmDeals { get; set; } //with CrmDeals


        public int TenantId { get; set; }

        [NotMapped]
        public string Lang { get; set; }

    }
}
