using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._VendorItemsReport.Dto
{
    public class VendorItemDto
    {
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }

        public string VendorNumber { get; set; }
        public string VendorNameAr { get; set; }
        public long? VendorId { get; set; }
        public string DocDate { get; set; }
        public string Source { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string tel { get; set; }
        public string Comments { get; set; }
        public decimal Balance { get; set; }
        public string SourceId { get; set; }
        public string SourceType { get; set; }
    }
}
