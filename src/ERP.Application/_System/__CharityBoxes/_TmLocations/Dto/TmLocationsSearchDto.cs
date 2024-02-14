using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    public class TmLocationsSearchDto
    {
        //public long? CityLkpId { get;  set; }
        public string LocationNumber { get;  set; }
        public string LocationName { get;  set; }
        public long? RegionId { get;  set; }

        public override string ToString()
        {
            return $"Params.LocationNumber={LocationNumber}&Params.LocationName={LocationName}&Params.RegionId={RegionId}";
        }
    }
}
