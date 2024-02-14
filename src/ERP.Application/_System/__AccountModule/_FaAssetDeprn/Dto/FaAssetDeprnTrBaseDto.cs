using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnTrBaseDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long? FaAssetDeprnHdId { get; set; }

        public long? AssetId { get; set; }
    }
}
