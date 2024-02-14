using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnTrDtlBaseDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public decimal? DebitAmount { get; protected set; }

        public decimal? CreditAmount { get; protected set; }

        public long? AccountId { get; set; }
    }
}
