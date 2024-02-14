using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMap(typeof(ScCommitteeDetail))]
    public class ScCommitteeDetailEditDto : EntityDto<long>, IDetailRowStatus, IMustHaveTenant
    {
        public long CommitteeId { get; set; }

        public long RequestStudyId { get; set; }

        public decimal? AidAmount { get; set; }

        public int? NoOfMonths { get; set; }

        public long? OtherAidLkpId { get; set; }

        public int? OtherMonthNo { get; set; }

        public bool IsMedicine { get; set; }

        [MaxLength(200)]
        public string CashingTo { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string rowStatus { get; set; }
        public int TenantId { get; set; }

        [MaxLength(4000)]
        public string DecisionNotes { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ICollection<ScCommitteeDetailsElectronicAidDto> DetailsElectronicAids { get; set; }
    }
}
