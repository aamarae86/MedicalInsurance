namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    public class ScCommitteesCheckSearchDto
    {
        public string OperationNumber { get; set; }
        public string OperationDate { get; set; }
        public long? StatusLkpId { get; set; }
        public long? CommitteeId { get; set; }
        public string Notes { get; set; }
        public override string ToString() => $"Params.OperationNumber={OperationNumber}&Params.OperationDate={OperationDate}&Params.StatusLkpId={StatusLkpId}&Params.CommitteeId={CommitteeId}&Params.Notes={Notes}";
    }
}
