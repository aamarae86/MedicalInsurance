using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._VendorItemsReport.Dto
{
    public class VendorItemSearchDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? TenantId { get; set; }        
        public long? VendorId { get; set; }       
        public bool? IsNotSettled { get; set; }       
        //public string Lang { get; set; }
      
    }
}
