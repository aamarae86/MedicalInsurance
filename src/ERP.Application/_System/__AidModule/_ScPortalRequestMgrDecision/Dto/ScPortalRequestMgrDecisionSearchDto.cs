namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    public class ScPortalRequestMgrDecisionSearchDto
    {
        public string FromDecisionDate { get;  set; }
        public string ToDecisionDate { get;  set; }
        public string DecisionNumer { get;  set; }
        public long? StatusLkpId { get;  set; }
        public long? PortalRequestStudyId { get;  set; }
        public long? CaseNameId { get; set; }
        public override string ToString() => $"Params.FromDecisionDate={FromDecisionDate}&Params.ToDecisionDate={ToDecisionDate}&Params.DecisionNumer={DecisionNumer}&Params.StatusLkpId={StatusLkpId}&Params.StatusLkpId={StatusLkpId}&Params.PortalRequestStudyId={PortalRequestStudyId}&Params.CaseNameId={CaseNameId}";
    }
}
