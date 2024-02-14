using ERP._System._GlCodeComDetails.Dto;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnTrDtlDto : FaAssetDeprnTrDtlBaseWithLookupsDto
    {
        public string AccountNameAr { get; set; }

        public string AccountNameEn { get; set; }

        public string AccountNumber { get; set; }

        public GlCodeComDetailsDto GlCodeComDetails { get; set; }
    }
}
