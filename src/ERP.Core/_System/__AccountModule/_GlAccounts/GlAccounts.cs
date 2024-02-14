using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP._System._FndLookupValues;
using ERP._System._GlCodeComDetails;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._GlAccounts
{
    public class GlAccounts : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        #region Props

        [Required]
        [MaxLength(100)]
        public string Code { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionEn { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string DescriptionAr { get; protected set; }
 
        public bool TrialBalance { get; protected set; }
 
        public bool CashFlow { get; protected set; }
 
        public bool Expense { get; protected set; }
 
        public bool Revenue { get; protected set; }
 
        public bool Libility { get; protected set; }
 
        public bool Assets { get; protected set; }
 
        public bool ProfitLoss { get; protected set; }
 
        public bool BalanceSheet { get; protected set; }
 
        public bool Disabled { get;protected set; }

        public bool IsActive { get; set; }

        public long? ParentId { get; protected set; }

        public long? IdMap { get; protected set; }

        public long? ParentIdMap { get; protected set; }

        [MaxLength(4000)]
        public string ParentPath { get; protected set; }

        public long NatureOfAccountLkpId { get; protected set; }

        [ForeignKey(nameof(NatureOfAccountLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public GlAccounts GlAccount { get; protected set; }
        
        public virtual ICollection<GlCodeComDetails> GlCodeComDetails { get; protected set; }

        [InverseProperty(nameof(GlAccMappingTrDtl.GlAccDetailFrom))]
        public virtual ICollection<GlAccMappingTrDtl> GlAccMappingTrDtlFrom { get; protected set; }

        [InverseProperty(nameof(GlAccMappingTrDtl.GlAccDetailTo))]
        public virtual ICollection<GlAccMappingTrDtl> GlAccMappingTrDtlTo { get; protected set; }

        public int TenantId { get; set; }

        public long? TenxMigrationId { get; set; }
        #endregion
    }
}
