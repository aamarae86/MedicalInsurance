using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnHdBaseDto : PostAuditedEntityDto<long>
    {

        public string AssetDeprnDate { get; set; }

        [MaxLength(200)]
        public string AssetDeprnName { get; set; }

        public long? PeriodId { get; set; }

        public long? AssetId { get; set; }
    }
}
