using Abp.Domain.Entities;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__AccountModuleExtend._FaAssets;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._FaAssetDeprn
{
    public class FaAssetDeprnHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string AssetDeprnNumber { get; protected set; }

        public DateTime? AssetDeprnDate { get; protected set; }

        [MaxLength(200)]
        public string AssetDeprnName { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues StatusLkp { get; protected set; }
        public long? StatusLkpId { get; protected set; }

        [ForeignKey(nameof(PeriodId))]
        public GlPeriodsDetails Period { get; protected set; }

        public long? PeriodId { get; protected set; }

        [ForeignKey(nameof(AssetId))]
        public FaAssets Asset { get; protected set; }
        public long? AssetId { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<FaAssetDeprnTr> AssetDeprnTrs { get; protected set; }
    }
}
