namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnHdBaseWithLookupsDto : FaAssetDeprnHdBaseDto
    {
        public string AssetDescription { get; set; }
        public string AssetNumber { get; set; }
        public string StatusAr { get; set; }
        public string StatusEn { get; set; }
        public string PeriodAr { get; set; }
        public string PeriodEn { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PeriodAccountId { get; set; }
    }
}
