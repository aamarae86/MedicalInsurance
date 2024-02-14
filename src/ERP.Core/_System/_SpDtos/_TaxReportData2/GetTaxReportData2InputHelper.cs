using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._SpDtos._TaxReportData2
{
    public class GetTaxReportData2InputHelper : IMustHaveTenant
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }
        public string Lang { get; set; }

        public int TenantId { get; set; }
        public int ArCustomerId { get; set; }
        public string CustomerName { get; set; }
        public override string ToString() => $"?FromDate={FromDate}&ToDate={ToDate}&ArCustomerId={ArCustomerId}&Lang={Lang}";

    }
}
