using AutoMapper;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    [AutoMap(typeof(ScDeliveryOtherAids))]
    public class ScDeliveryOtherAidsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string OperationNumber { get; set; }

        [Required]
        public string OperationDate { get; set; }

        public string MaturityDate { get; set; }

        public long StatusLkpId { get; set; }

        public long? CommitteeId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public ScCommitteeDto ScCommittee { get; set; }

        public virtual ICollection<ScDeliveryOtherAidDetailsDto> OtherAidDetails { get; set; }
    }
}
