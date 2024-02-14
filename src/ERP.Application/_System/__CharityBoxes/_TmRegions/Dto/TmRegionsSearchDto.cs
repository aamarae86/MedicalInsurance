using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmRegions.Dto
{
    public class TmRegionsSearchDto
    {
        public long? CityLkpId { get;  set; }
        public string RegionNumber { get;  set; }
        public string RegionName { get;  set; }
        public override string ToString()
        {
            return $"Params.RegionNumber={RegionNumber}&Params.RegionName={RegionName}&Params.CityLkpId={CityLkpId}";
        }
    }
}
