using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsSales.Input
{
    public class ArJobCardInput
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? ArCustomerId { get; set; }
        public string JobNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public string Lang { get; set; }
        public int TenantId { get; set; }
    }

    public class ArJobCardHelperInput
    {        

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        
        public long? ArCustomerLkpId { get; set; }
        public string ArCustomerLkpIdtxt { get; set; }

        public long? JobNumberLkpId { get; set; }
        public string JobNumberLkpIdtxt { get; set; }
        
        public string Lang { get; set; }
        public long? StatusLkpId { get; set; }
        public string StatusLkpIdtxt { get; set; }

        public int TenantId { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&StatusLkpId={StatusLkpId}&FromDate={FromDate}&ToDate={ToDate}&ArCustomerLkpId={ArCustomerLkpId}&JobNumberLkpId={JobNumberLkpId}&JobNumberLkpIdtxt={JobNumberLkpIdtxt}&TenantId={TenantId}";
        }
    }
}
