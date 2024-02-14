namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    public class ScMaintenanceContractSearchDto
    {
        public string MaintenanceContractNumber { get; set; }

        public string MaintenanceContractDate { get; set; }

        public long? ScMaintenanceQuotationId { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.MaintenanceContractNumber={MaintenanceContractNumber}&Params.MaintenanceContractDate={MaintenanceContractDate}&Params.StatusLkpId={StatusLkpId}&Params.ScMaintenanceQuotationId={ScMaintenanceQuotationId}";
    }
}
