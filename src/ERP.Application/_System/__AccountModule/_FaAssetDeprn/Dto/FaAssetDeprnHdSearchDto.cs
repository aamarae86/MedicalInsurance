namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnHdSearchDto
    {
        public string AssetDeprnNumber { get; set; }

        public long? PeriodId { get; set; }

        public long? AssetId { get; set; }

        public long? StatusId { get; set; }

        public override string ToString()
            => $"Params.AssetId={AssetId}&Params.StatusId={StatusId}&Params.AssetDeprnNumber={AssetDeprnNumber}&Params.PeriodId={PeriodId}";
    }

}
