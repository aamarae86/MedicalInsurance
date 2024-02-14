using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    [AutoMap(typeof(ScDeliveryOtherAids))]
    public class ScDeliveryOtherAidsCreateDto
    {
        [MaxLength(30)]
        public string OperationNumber { get; set; }

        [Required]
        public string OperationDate { get; set; }

        public string MaturityDate { get; set; }

        public long StatusLkpId => 917;

        public long? CommitteeId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScDeliveryOtherAidDetailsDto> OtherAidDetails { get; set; }
    }
}
