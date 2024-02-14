using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    [AutoMap(typeof(PmTerminateContracts))]
    public class CreatePmTerminateContractsDto
    {
        public long? PmContractId { get; set; }

        public long? StatusLkpId => 227;

        public string TerminationDate { get; set; }

        [MaxLength(30)]
        public string TerminationNumber { get; set; }

        public decimal? FineAmount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public bool? IsTransferDepositToCustomer { get; set; }
    }
}
