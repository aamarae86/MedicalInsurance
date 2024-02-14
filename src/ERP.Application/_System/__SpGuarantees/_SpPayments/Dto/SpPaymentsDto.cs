using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    [AutoMap(typeof(SpPayments))]
    public class SpPaymentsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string PaymentNumber { get; set; }

        [MaxLength(200)]
        public string PaymentName { get; set; }

        public long StatusLkpId { get; set; }

        public long FromPeriodId { get; set; }

        public long ToPeriodId { get; set; }

        public long? SponsorCategoryLkpId { get; set; }

        public long? SpCaseId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string CaseNumber { get; set; }

        public decimal Total { get; set; }

        public virtual FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual FndLookupValuesDto FndSponsorCategoryLkp { get; set; }

        public virtual GlPeriodsDetailsDto FromPeriod { get; set; }

        public virtual GlPeriodsDetailsDto ToPeriod { get; set; }

        public virtual SpCasesDto SpCases { get; set; }

        public virtual ICollection<SpPaymentPersonsDto> PaymentPersons { get; set; }

    }
}
