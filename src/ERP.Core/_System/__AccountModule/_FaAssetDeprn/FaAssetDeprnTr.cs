using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__AccountModuleExtend._FaAssets;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._FaAssetDeprn
{
    public class FaAssetDeprnTr : Entity<long>, IMustHaveTenant
    {

        [ForeignKey(nameof(FaAssetDeprnHdId))]
        public FaAssetDeprnHd AssetDeprnHd { get; protected set; }
        public long? FaAssetDeprnHdId { get; protected set; }

        [ForeignKey(nameof(AssetId))]
        public FaAssets Asset { get; protected set; }
        public long? AssetId { get; protected set; }

        public int TenantId { get; set; }

        public virtual ICollection<FaAssetDeprnTrDtl> AssetDeprnTrDtls { get; protected set; }
    }
}
