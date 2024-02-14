using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Dto
{
    public class ScPortalRequestStudySearchDto
    {
        public string FromStudyDate { get; set; }
        public string ToStudyDate { get; set; }
        public string StudyNumber { get; set; }
        public long? PortalRequestId { get; set; }
        public long? StatusLkpId { get; set; }
        public long? CaseNameId { get; set; }
        public override string ToString() => $"Params.FromStudyDate={FromStudyDate}&Params.ToStudyDate={ToStudyDate}&Params.StudyNumber={StudyNumber}&Params.PortalRequestId={PortalRequestId}&Params.StatusLkpId={StatusLkpId}&Params.CaseNameId={CaseNameId}";
    }
}
