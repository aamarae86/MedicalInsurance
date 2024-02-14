using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAids.Input
{
    public class rptScPortalAidsPerNationalityInput
    {
        public long TenantId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public long? NationalityLkpId { get; set; }
        public string Lang { get; set; }
    }

    public class rptScPortalAidsPerNationalityHelperInput
    {
        public long TenantId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? NationalityLkpId { get; set; }
        public string NationalityLkpIdtxt { get; set; }
        public string Lang { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&NationalityLkpId={NationalityLkpId}&ToDate={ToDate}&FromDate={FromDate}&TenantId={TenantId}";
        }
    }
}
