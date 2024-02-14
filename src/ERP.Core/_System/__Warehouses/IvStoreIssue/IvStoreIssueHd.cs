using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public class IvStoreIssueHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [MaxLength(20)]
        public string StoreIssueNumber { get; protected set; }

        [Required]
        public DateTime StoreIssueDate { get; protected set; }

        [Required]
        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [Required]
        public long IvWarehouseId { get; protected set; }

        [ForeignKey(nameof(IvWarehouseId))]
        public IvWarehouses Warehouses { get; protected set; }

        [Required]
        public long IssueTypeLkpId { get; protected set; }

        [ForeignKey(nameof(IssueTypeLkpId))]
        public FndLookupValues FndLookupValuesIssueTypeLkp { get; protected set; }

        [MaxLength(20)]
        public string ManualNo { get; protected set; }

        public long? BeneficiaryTypeLkpId { get; protected set; }

        [ForeignKey(nameof(BeneficiaryTypeLkpId))]
        public FndLookupValues FndLookupValuesBeneficiaryTypeLkp { get; protected set; }

        [MaxLength(200)]
        public string BeneficiaryName { get; protected set; }

        [MaxLength(4000)]
        public string Comment { get; protected set; }

        [Required]
        public long AccountId { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public ICollection<IvStoreIssueTr> IvStoreIssueTrs { get; protected set; }
    }
}
