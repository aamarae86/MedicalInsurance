namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto
{
    public class FmMaintRequisitionsExeSearchDto
    {
        public long? ExecuteTypeLkpId { get; set; }

        public long? StatusLkpId { get; set; }

        public string EngineerNumber { get; set; }

        public string ContractNumber { get; set; }

        public override string ToString() => $"Params.ExecuteTypeLkpId={ExecuteTypeLkpId}&Params.ContractNumber={ContractNumber}&Params.EngineerNumber={EngineerNumber}&Params.StatusLkpId={StatusLkpId}";
    }
}
