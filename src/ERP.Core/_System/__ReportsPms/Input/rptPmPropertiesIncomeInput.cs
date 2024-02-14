using System;

namespace ERP._System.__ReportsPms.Input
{
    public class rptPmPropertiesIncomeInput
    {
        public long? PmOwnerId { get; set; }
        public long? PropertyId { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public int? TenantId { get; set; }
        public long PeriodsYearId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Lang { get; set; }
    }

    public class rptPmPropertiesIncomeHelperInput
    {
        public long? PmOwnerId { get; set; }

        public long PeriodsYearId { get; set; }
        public string PeriodsYearIdtxt { get; set; }

        public string PmOwnerIdtxt { get; set; }
        public string PmOwnerIdNumber { get; set; }
        public long? PropertyId { get; set; }
        public string PropertyIdtxt { get; set; }
        public string PropertyIdNumber { get; set; }
        public long? PmUnitTypeLkpId { get; set; }
        public string PmUnitTypeLkpIdtxt { get; set; }
        public int? TenantId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&PeriodsYearId={PeriodsYearId}&ToDate={ToDate}&FromDate={FromDate}&TenantId={TenantId}&PmUnitTypeLkpId={PmUnitTypeLkpId}&PropertyId={PropertyId}&PmOwnerId={PmOwnerId}";
        }
    }
}
