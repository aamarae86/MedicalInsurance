using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmContract.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto
{
    [AutoMap(typeof(PmCancellationContracts))]
    public class PmCancellationContractsDto : PostAuditedEntityDto<long>
    {
        [MaxLength(30)]
        public string CancellationNumber { get; set; }

        public string CancellationDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? PmContractId { get; set; }

        public int? FinePeriodPerDays { get; set; }

        public decimal? FineAmount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long? AccountId { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public PmContractDto PmContract { get; set; }

        public GlCodeComDetailsDto GlCodeComDetails { get; set; }

    }
}
