namespace ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto
{
    public class ScFndPortalIntervalSettingSearchDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public int? NumberOfRequest { get; set; }

        public override string ToString() => $"Params.NumberOfRequest={NumberOfRequest}&Params.FromDate={FromDate}&Params.ToDate={ToDate}";

    }
}
