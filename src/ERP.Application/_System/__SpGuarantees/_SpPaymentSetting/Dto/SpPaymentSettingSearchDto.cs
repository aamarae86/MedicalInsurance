namespace ERP._System.__SpGuarantees._SpPaymentSetting.Dto
{
    public class SpPaymentSettingSearchDto
    {
        public long? SponsorCategoryLkpId { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public override string ToString() => $"Params.SponsorCategoryLkpId={SponsorCategoryLkpId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}";
    }
}
