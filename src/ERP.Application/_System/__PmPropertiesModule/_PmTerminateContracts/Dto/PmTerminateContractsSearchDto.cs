using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    [AutoMapFrom(typeof(PmTerminateContracts))]
    public class PmTerminateContractsSearchDto
    {
        public string TerminationNumber { get;  set; }
        public string TerminationDate { get;  set; }
        public long? PmContractId { get; set; }
        public long? StatusLkpId { get;  set; }
        public long? PmTenantId { get;  set; }
        public override string ToString()
        {
            return $"Params.TerminationNumber={TerminationNumber}&Params.TerminationDate={TerminationDate}&Params.PmContractId={PmContractId}&Params.StatusLkpId={StatusLkpId}&Params.PmTenantId={PmTenantId}";
        }
    }
}
