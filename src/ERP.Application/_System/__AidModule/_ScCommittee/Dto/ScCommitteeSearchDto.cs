using System;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    public class ScCommitteeSearchDto
    {
        public string CommitteeNumber { get; set; }

        public string CommitteeDateFrom { get; set; }

        public string CommitteeDateTo { get; set; }

        public string CommitteeName { get; set; }

        public long StatusLkpId { get; set; }

        public override string ToString()
        {
            return $"Params.CommitteeNumber={CommitteeNumber}&Params.CommitteeName={CommitteeName}&Params.StatusLkpId={StatusLkpId}&Params.CommitteeDateFrom={CommitteeDateFrom}&Params.CommitteeDateTo={CommitteeDateTo}";
        }
    }
}
