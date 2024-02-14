using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmContract.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    [AutoMapFrom(typeof(PmTerminateContracts))]
    public class PmTerminateContractsDto : PostAuditedEntityDto<long>
    {
        public long? PmContractId { get; set; }

        public long? StatusLkpId { get; set; }

        public string TerminationDate { get; set; }

        [MaxLength(30)]
        public string TerminationNumber { get; set; }

        public decimal? FineAmount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public bool? IsTransferDepositToCustomer { get; set; }

        public FndLookupValuesDto FndLookupValuesPmTerminateContractsStatusLkp { get; set; }

        public PmContractDto PmContract { get; set; }
    }
}
