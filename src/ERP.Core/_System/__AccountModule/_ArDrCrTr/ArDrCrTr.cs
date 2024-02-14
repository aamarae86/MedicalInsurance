using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ArDrCrHd;
using ERP._System._FndTaxType;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System._ArDrCrTr
{
    public class ArDrCrTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long? AccountId { get;protected set; }
        [MaxLength(4000)]
        public string Description { get; protected set; }
        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get;protected set; } 
        
        public decimal? Tax { get;protected set; }
        public long? ArDrCrHdId { get;protected set; }
        public int TenantId { get ; set ; }
        public long? FndTaxtypeId { get; protected set; }

        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxType FndTaxType { get; protected set; }
        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(ArDrCrHdId))]
        public ArDrCrHd ArDrCrHd { get; protected set; }
        public long? TenxMigrationId { get; set; }

    }
}
