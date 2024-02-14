using Abp.AutoMapper;
using ERP._System._GlAccDetails;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    //[AutoMap(typeof(AccountsStatmentHelperInput))]
    public class VendorItemReportInput
    {
        public long? VendorId { get; set; }
       // public long? IvWarehouseId { get; set; }
       public bool? IsNotSettled { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        public long TenantId { get; set; }

    }
}
