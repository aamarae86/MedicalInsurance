using Abp.Domain.Entities;
using ERP._System.__CRM.Leads;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CRM.Deals
{
   public class CrmDeals : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime DealDate { get; set; }
        public string DealName { get; set; }

        public long DealTypeLkpId { get; set; }
        [ForeignKey(nameof(DealTypeLkpId))]
        public FndLookupValues DealTypeLkps { get; set; } //"CrmDealsType"

        [MaxLength(150)]
        public string NextStep { get; set; }

        public long LeadSourceLkpId { get; set; }
        [ForeignKey(nameof(LeadSourceLkpId))]
        public FndLookupValues LeadSourceLkps { get; set; } //"CrmLeadsPersonsSource"

        public long CrmLeadsPersonsId { get; set; }
        [ForeignKey(nameof(CrmLeadsPersonsId))]
        public CrmLeadsPersons CrmLeadsPersons { get; set; }  

        public decimal Amount { get; set; }
        public DateTime? ClosingDate { get; set; }
        public long StageLkpID { get; set; }
        [ForeignKey(nameof(StageLkpID))]
        public FndLookupValues StageLkps { get; set; }  
        public string Probability { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public int TenantId { get; set; }

        [NotMapped]
        public string Lang { get; set; }

        [MaxLength(500)]
        public string Company { get; set; }


        public virtual ICollection<CrmDealsAttachments> CrmDealsAttachments { get; protected set; }
    }
}
