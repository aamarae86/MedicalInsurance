using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    [AutoMap(typeof(PmTerminateContracts))]
    public class PmTerminateContractsEditDto : EntityDto<long>
    {
        public long? PmContractId { get; set; }

        public string TerminationDate { get; set; }

        public decimal? FineAmount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public bool? IsTransferDepositToCustomer { get; set; }
    }
}
