namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    public class GlJeIntegrationHeadersSearchDto
    {
        public string GlJeIntegrationNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? PeriodId { get; set; }

        public string JeName { get; set; }

        public string GlJeIntegrationDate { get; set; }

        public int? CurrencyId { get; set; }

        public long? GlJeIntegrationSourceLkpId { get; set; }

        public override string ToString() => $"Params.GlJeIntegrationNumber={GlJeIntegrationNumber}&Params.GlJeIntegrationSourceLkpId={GlJeIntegrationSourceLkpId}&Params.CurrencyId={CurrencyId}&Params.GlJeIntegrationDate={GlJeIntegrationDate}&Params.JeName={JeName}&Params.PeriodId={PeriodId}&Params.StatusLkpId={StatusLkpId}";
    }
}
