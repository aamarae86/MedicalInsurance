using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    [AutoMap(typeof(FaAssetDeprnHd))]
    public class FaAssetDeprnHdCreateDto : FaAssetDeprnHdBaseDto
    {
        public long? StatusLkpId => 898;

        [MaxLength(30)]
        public string AssetDeprnNumber { get; set; }
    }
}
