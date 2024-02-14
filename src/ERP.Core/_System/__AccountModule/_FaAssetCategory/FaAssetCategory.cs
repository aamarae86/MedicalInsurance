using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._GlCodeComDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AccountModule._FaAssetCategory
{
    public class FaAssetCategory : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string AssetCategoryNumber { get; protected set; }
        [MaxLength(200)]
        public string AssetCategoryNameAr { get; protected set; }
        [MaxLength(200)]
        public string AssetCategoryNameEn { get; protected set; }
        [MaxLength]
        public string Description { get; protected set; }
        public long? NoMonthsDepreciation { get;protected set; }
        public long? AssetCostAccountId { get;protected set; }
        public long? AssetClearingAccountId { get;protected set; }
        public long? AccDeprenAccountId { get;protected set; }
        public long? DeprenAccountId { get;protected set; }

        [ForeignKey(nameof(AssetCostAccountId)), Column(Order = 0)]
        public GlCodeComDetails GlCodeComDetailsAssetCostAccount { get; protected set; }

        [ForeignKey(nameof(AssetClearingAccountId)), Column(Order = 1)]
        public GlCodeComDetails GlCodeComDetailsAssetClearingAccount { get; protected set; }

        [ForeignKey(nameof(AccDeprenAccountId)), Column(Order = 2)]
        public GlCodeComDetails GlCodeComDetailsAccDeprenAccount { get; protected set; }

        [ForeignKey(nameof(DeprenAccountId)), Column(Order = 3)]
        public GlCodeComDetails GlCodeComDetailsDeprenAccount { get; protected set; }

        public int TenantId { get ; set ; }
    }
}
