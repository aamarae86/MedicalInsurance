using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    [AutoMap(typeof(ScDeliveryOtherAids))]
    public class ScDeliveryOtherAidsEditDto : EntityDto<long>
    {
        [Required]
        public string OperationDate { get; set; }

        public string MaturityDate { get; set; }

        public long? CommitteeId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScDeliveryOtherAidDetailsDto> OtherAidDetails { get; set; }
    }
}
