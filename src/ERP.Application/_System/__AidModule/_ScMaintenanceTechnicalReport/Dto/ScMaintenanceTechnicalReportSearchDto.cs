namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    public class ScMaintenanceTechnicalReportSearchDto
    {
        public string TechnicalReportNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? PortalUserId { get; set; }

        public string TechnicalReportDate { get; set; }

        public string PortalRequestNumber { get; set; }

        public override string ToString() => $"Params.TechnicalReportNumber={TechnicalReportNumber}&Params.PortalUserId={PortalUserId}&Params.PortalRequestNumber={PortalRequestNumber}&Params.TechnicalReportDate={TechnicalReportDate}&Params.StatusLkpId={StatusLkpId}";
    }
}
