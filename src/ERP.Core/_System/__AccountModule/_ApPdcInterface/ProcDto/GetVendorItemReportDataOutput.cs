using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public  class GetVendorItemReportDataOutput
    {
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }

        public string VendorNumber { get; set; }
        public string VendorNameAr { get; set; }
        public long? VendorId { get; set; }
        public DateTime? HdDate { get; set; }
        public string Source { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string tel { get; set; }
        public string Comments { get; set; }
        public DateTime? DocDate { get; set; }
        public long? SourceId { get; set; }
        public string SourceType { get; set; }



    }
}
