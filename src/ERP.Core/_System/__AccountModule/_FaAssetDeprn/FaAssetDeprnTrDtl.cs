using Abp.Domain.Entities;
using ERP._System._GlCodeComDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._FaAssetDeprn
{
    public class FaAssetDeprnTrDtl : Entity<long>, IMustHaveTenant
    {
        [ForeignKey(nameof(FaAssetDeprnTrId))]
        public FaAssetDeprnTr AssetDeprnTr { get; protected set; }
        public long? FaAssetDeprnTrId { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? DebitAmount { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? CreditAmount { get; protected set; }

        public long? AccountId { get; protected set; }

        [ForeignKey(nameof(AccountId))]
        public GlCodeComDetails GlCodeComDetails { get; protected set; }

        public int TenantId { get; set; }
    }

}
