using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    [AutoMap(typeof(SpPaymentPersons))]
    public class SpPaymentPersonsDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpPaymentId { get; set; }

        public long SpCaseId { get; set; }

        public long CaseStatusLkpId { get; set; }

        public long SponsorCategoryLkpId { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalAmount { get; set; }

        public string SponsorCategoryAr { get; set; }

        public string SponsorCategoryEn { get; set; }

        public string CaseStatusAr { get; set; }

        public string CaseStatusEn { get; set; }

        public string CaseName { get; set; }

        public string CaseNumber { get; set; }

        public string rowStatus { get; set; }

        public virtual ICollection<SpPaymentPersonDetailsDto> PaymentPersonDetails { get; set; }
    }
}
