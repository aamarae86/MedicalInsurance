using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._SpDtos._TaxReportData2
{
    public class GetTaxReportData2Input : IMustHaveTenant
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public string Lang { get; set; }

        public int TenantId { get; set; }
        public int ArCustomerId { get; set; }

    }


}
