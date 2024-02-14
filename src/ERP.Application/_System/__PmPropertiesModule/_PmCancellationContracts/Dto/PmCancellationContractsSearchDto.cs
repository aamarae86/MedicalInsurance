using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto
{
    public class PmCancellationContractsSearchDto
    {
        public string CancellationNumber { get;  set; }
        public string CancellationDate { get; set; }
        public long? PmContractId { get;  set; }
        public long? StatusLkpId { get;  set; }
        public long? PmTenantName { get;  set; }
        public override string ToString() => $"Params.CancellationNumber={CancellationNumber}&Params.CancellationDate={CancellationDate}&Params.PmContractId={PmContractId}&Params.StatusLkpId={StatusLkpId}&Params.PmTenantName={PmTenantName}";
    }
}
