namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    public class SpContractsSearchDto
    {

        public string ContractNumber { get; set; }

        public string BeneficentNumber { get; set; }

        public string ContractDate { get; set; }

        public string MobileNumber { get; set; }

        public string SpCaseNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? SpBeneficentId { get; set; }

        public long? SpCaseId { get; set; }

        public override string ToString()
         => $"Params.BeneficentNumber={BeneficentNumber}&Params.SpCaseNumber={SpCaseNumber}&" +
            $"Params.MobileNumber={MobileNumber}&Params.ContractNumber={ContractNumber}" +
            $"&Params.ContractDate={ContractDate}&Params.SpCaseId={SpCaseId}&Params.StatusLkpId={StatusLkpId}&Params.SpBeneficentId={SpBeneficentId}";

    }
}
