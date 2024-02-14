using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._FndUsers.Dto
{
    public class FndUsersSearchDto
    {
        public string Name { get; set; }

        public long? GenderLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        public override string ToString() 
        => $"Params.Name={Name}&Params.GenderLkpId={GenderLkpId}&Params.CityLkpId={CityLkpId}&Params.NationalityLkpId={NationalityLkpId}";

    }
}
