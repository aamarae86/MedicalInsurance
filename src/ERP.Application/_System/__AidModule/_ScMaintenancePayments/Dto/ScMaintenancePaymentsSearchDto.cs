namespace ERP._System.__AidModule._ScMaintenancePayments.Dto
{
    public class ScMaintenancePaymentsSearchDto
    {
        public string MaintenancePaymentNumber { get; set; }

        public string MaintenanceContractNumber { get; set; }

        public string MaintenancePaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public long? ScMaintenanceContractPaymentId { get; set; }

        public long? StatusLkpId { get; set; }

        public long? VendorId { get; set; }

        public override string ToString() => $"Params.MaintenancePaymentNumber={MaintenancePaymentNumber}&Params.MaturityDate={MaturityDate}&Params.MaintenancePaymentNumber={MaintenancePaymentNumber}&Params.VendorId={VendorId}&Params.MaintenancePaymentDate={MaintenancePaymentDate}&Params.StatusLkpId={StatusLkpId}&Params.ScMaintenanceContractPaymentId={ScMaintenanceContractPaymentId}";
    }
}
