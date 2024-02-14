namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    public class FmContractsSearchDto
    {
     
        public long? StatusLkpId { get; set; }
        public string ContractDate { get; set; }
        public long? VendorId { get; set; }
        public string ContractNumber { get; set; }
        public override string ToString()
            => $"Params.VendorId={VendorId}&Params.ContractNumber={ContractNumber}&Params.ContractDate={ContractDate}&Params.StatusLkpId={StatusLkpId}";
    }
}
