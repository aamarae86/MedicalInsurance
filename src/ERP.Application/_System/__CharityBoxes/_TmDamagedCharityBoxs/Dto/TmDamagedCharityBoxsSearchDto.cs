using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    public class TmDamagedCharityBoxsSearchDto
    {
        
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string DamagedCharityBoxsNumber { get; set; }

        public long? TmSupervisorId { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.DamagedCharityBoxsNumber={DamagedCharityBoxsNumber}&Params.ToDate={ToDate}&Params.FromDate={FromDate}&Params.TmSupervisorId={TmSupervisorId}&Params.StatusLkpId={StatusLkpId}";
    }
}
