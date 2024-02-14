using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmProperties.Dto
{
    public class PmPropertiesSearchDto
    {
        public long? PmOwnerId { get;  set; }
        public long? PropertyId { get; set; }
        public long? StatusLkpId { get;  set; }
        public long? CityLkpId { get;  set; }

        public override string ToString() => $"Params.PmOwnerId={PmOwnerId}&Params.PropertyId={PropertyId}&Params.StatusLkpId={StatusLkpId}&Params.CityLkpId={CityLkpId}";

    }
}
