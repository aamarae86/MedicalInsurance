using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._SpDtos._TaxReportData
{
    public class GetTaxReportDataInput : IMustHaveTenant
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public string Lang { get; set; }

        public int TenantId { get; set; }
        
    }

    public class GetTaxReportDataInputHelper : IMustHaveTenant
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }
        public string Lang { get; set; }

        public int TenantId { get; set; }
        public override string ToString() => $"?FromDate={FromDate}&ToDate={ToDate}&Lang={Lang}";

    }
}
