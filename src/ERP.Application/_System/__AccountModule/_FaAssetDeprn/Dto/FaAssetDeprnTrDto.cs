using System.Collections.Generic;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnTrDto : FaAssetDeprnTrBaseWithLookupsDto
    {
        public ICollection<FaAssetDeprnTrDtlDto> AssetDeprnTrDtls { get; set; }
    }
}
