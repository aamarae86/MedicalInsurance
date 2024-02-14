using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsTms.Inputs
{
    public class TmCharityBoxListScreenDataHelperInput
    {
        public int TenantId { get; set; }
        public long? CharityId { get; set; }
        public string CharityIdtxt { get; set; }
        public string CharityBoxBarcode { get; set; }
        public long? CharityStatus { get; set; }
        public string CharityStatustxt { get; set; }
        public long? BoxTypeName { get; set; }
        public string BoxTypeNametxt { get; set; }
        public long? CityId { get; set; }
        public string CityIdtxt { get; set; }
        public long? RegionId { get; set; }
        public string RegionIdtxt { get; set; }
        public long? LocationId { get; set; }
        public string LocationIdtxt { get; set; }
        public long? LocationSubId { get; set; }
        public string LocationSubIdtxt { get; set; }
        public string Lang { get; set; }
        public override string ToString() =>
            $"?CharityId={CharityId}" +
            $"&TenantId={TenantId}" +
            $"&CharityBoxBarcode={CharityBoxBarcode}" +
            $"&CharityStatus={CharityStatus}" +
            $"&BoxTypeName={BoxTypeName}" +
            $"&CityId={CityId}" +
            $"&RegionId={RegionId}" +
            $"&LocationId={LocationId}" +
            $"&Lang={Lang}" +
            $"&LocationSubId={LocationSubId}";
    }
}
