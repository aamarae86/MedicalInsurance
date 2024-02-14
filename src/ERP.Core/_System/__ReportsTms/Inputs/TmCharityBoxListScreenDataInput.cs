using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsTms.Inputs
{
    public class TmCharityBoxListScreenDataInput
    {
        public int TenantId { get; set; }
        public long? CharityId { get; set; }
        public string CharityBoxBarcode { get; set; }
        public long? CharityStatus { get; set; }
        public long? BoxTypeName { get; set; }
        public long? CityId { get; set; }
        public long? RegionId { get; set; }
        public long? LocationId { get; set; }
        public long? LocationSubId { get; set; }
    }
}
