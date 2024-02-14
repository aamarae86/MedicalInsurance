using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    [AutoMap(typeof(SpPayments))]
    public class SpPaymentsEditDto : EditEntityDto<long>
    {
        [MaxLength(200)]
        public string PaymentName { get; set; }

        public long FromPeriodId { get; set; }

        public long ToPeriodId { get; set; }

        public long? SponsorCategoryLkpId { get; set; }

        public long? SpCaseId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<SpPaymentPersonsDto> PaymentPersons { get; set; }
    }
}
