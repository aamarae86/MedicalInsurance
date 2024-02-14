using System;

namespace ERP._System.__ReportsPms.Input
{
    public class PmContractsInput
    {
        public long? StatusLKkpId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? contractEndDate { get; set; }
        public long? PropertyId { get; set; }
        public long? PMTenantId { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public long? PmActivityId { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
    }

    public class PmContractsHelperInput
    {
        public long? StatusLKkpId { get; set; }
        public string StatusLKkpIdtxt { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ContractStartDate { get; set; }
        public string contractEndDate { get; set; }
        public long? PropertyId { get; set; }
        public string PropertyIdtxt { get; set; }
        public long? PMTenantId { get; set; }
        public string PMTenantIdtxt { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public string PmUnitTypeLkpIdtxt { get; set; }
        public long? PmActivityId { get; set; }
        public string PmActivityIdtxt { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&StatusLKkpId={StatusLKkpId}&FromDate={FromDate}&ToDate={ToDate}&ContractStartDate={ContractStartDate}&contractEndDate={contractEndDate}&PropertyId={PropertyId}&PMTenantId={PMTenantId}&PmUnitTypeLkpId={PmUnitTypeLkpId}&PmActivityId={PmActivityId}&TenantId={TenantId}";
        }
    }
}
