using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto
{
    [AutoMap(typeof(PmCancellationContracts))]
    public class CreatePmCancellationContractsDto
    {
        [MaxLength(30)]
        public string CancellationNumber { get; set; }

        public string CancellationDate { get; set; }

        public long? StatusLkpId => 228;

        public long? PmContractId { get; set; }

        public int? FinePeriodPerDays { get; set; }

        public decimal? FineAmount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? AccountId { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
    }
}
