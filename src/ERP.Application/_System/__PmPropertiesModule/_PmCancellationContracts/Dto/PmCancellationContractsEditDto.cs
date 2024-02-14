using Abp.Application.Services.Dto;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto
{
    [AutoMap(typeof(PmCancellationContracts))]
    public class PmCancellationContractsEditDto : EditEntityDto<long>
    {
        public string CancellationDate { get; set; }

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
