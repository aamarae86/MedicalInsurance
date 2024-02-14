namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnTrBaseWithLookupsDto : FaAssetDeprnTrBaseDto
    {
        public string AssetLifeInMonths { get; set; }

        public string AssetCurrentCost { get; set; }

        public string AssetOriginalCost { get; set; }

        public string AssetDescription { get; set; }

        public string AssetSalvageValue { get; set; }

        public string AssetProrateDate { get; set; }

        public string AssetNumber { get; set; }
    }
}
