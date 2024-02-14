using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    public class ScCampainsSearchDto
    {
        public string CampainName { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.CampainName={CampainName}&Params.StatusLkpId={StatusLkpId}";
    }

}
