using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    public class TmCharityBoxActionsSearchDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string ActionsNumber { get; set; }

        public long? TmSupervisorId { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString() => $"Params.ActionsNumber={ActionsNumber}&Params.ToDate={ToDate}&Params.FromDate={FromDate}&Params.TmSupervisorId={TmSupervisorId}&Params.StatusLkpId={StatusLkpId}";
    }
}
