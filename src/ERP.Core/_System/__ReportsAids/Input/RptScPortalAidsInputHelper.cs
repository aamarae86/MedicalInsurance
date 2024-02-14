using Abp.Domain.Entities;
using System;

namespace ERP._System.__ReportsAids.Input
{
    public class RptScPortalAidsInputHelper : IMustHaveTenant
    {
        public string Lang { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public long? RequestTypeLkpId { get; set; }

        public string RequestType { get; set; }

        public long? CityLkpId { get; set; }

        public string CityLkp { get; set; }

        public int TenantId { get; set; }

        public override string ToString() => $"?Lang={Lang}&ToDate={ToDate}&FromDate={FromDate}&RequestTypeLkpId={RequestTypeLkpId}&CityLkpId={CityLkpId}";
    }

    public class RptScPortalAidsInput : IMustHaveTenant
    {
        public string Lang { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public long? RequestTypeLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public int TenantId { get; set; }
    }
}
