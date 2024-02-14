namespace ERP._System.__PmPropertiesModule._PmContract.Dto
{
    public class PmContractSearchDto
    {
        public long? PmUnitTypeLkpId { get; set; }

        public long? PropertyId { get; set; }

        public long? PmTenantId { get; set; }

        public long? StatusLkpId { get; set; }

        public string ContractNumber { get; set; }

        public override string ToString()
         => $"Params.PmUnitTypeLkpId={PmUnitTypeLkpId}&Params.PropertyId={PropertyId}&Params.PmTenantId={PmTenantId}&Params.StatusLkpId={StatusLkpId}&Params.StatusLkpId={StatusLkpId}&Params.ContractNumber={ContractNumber}";

    }
}
