using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ScCampainsAid
{
    public class ScCampainsAid : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long CampainsAidCategoryLkpId { get;protected set; }

        [Column(TypeName = "nvarchar(200)")]
        [Required]
        [MaxLength(200)]
        public string AidName { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal AidAmount { get;protected set; }

        public bool IsActive { get; set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(CampainsAidCategoryLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        public virtual ICollection<ScCampainsDetail> ScCampainsDetails { get; set; }
    }
}
