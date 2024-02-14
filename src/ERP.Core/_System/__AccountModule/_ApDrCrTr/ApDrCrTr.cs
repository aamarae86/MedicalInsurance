using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ApDrCrHd;
using ERP._System._ArDrCrHd;
using ERP._System._FndTaxType;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AccountModule._ApDrCrTr
{
    public class ApDrCrTr : AuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(4000)]
        public string Description { get; protected set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Tax { get; protected set; }

        public long? FndTaxtypeId { get; protected set; }

        [ForeignKey(nameof(FndTaxtypeId))]
        public FndTaxType FndTaxType { get; protected set; }

        //----Foreign Keys
        public long? AccountId { get; protected set; }
        public long? ApDrCrHdId { get; protected set; }


        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        [ForeignKey(nameof(ApDrCrHdId))]
        public ApDrCrHd ApDrCrHd { get; protected set; }

    }

}
