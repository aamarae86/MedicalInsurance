using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapTo(typeof(ScCommitteeDetail))]
    public class ScCommitteeDetailCreateDto
    {
        public int TenantId { get; set; }

        public long CommitteeId { get; set; }

        public long RequestStudyId { get; set; }

        public long StatusLkpId { get; set; }

        public decimal? AidAmount { get; set; }

        public int? NoOfMonths { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScCommitteeDetailsElectronicAidDto> DetailsElectronicAids { get; set; }
    }
}
