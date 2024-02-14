using Abp.AutoMapper;
using ERP._System._GlAccDetails;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    
    public class ItemQtyPerWarehouseInput
    {
        public long? TrItemId { get; set; }
        public long? IvWarehouseId { get; set; }      
        public string Lang { get; set; }
        public long TenantId { get; set; }

    }
}
