using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    [AutoMapFrom(typeof(ScCommitteeDetail))]
    public class ScCommitteeDetailDto : PostAuditedEntityDto<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

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

        [MaxLength(4000)]
        public string DecisionNotes { get; set; }

        public long StatusLkpId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndOtherAidLkp { get; set; }

        #region flat properties
        public string PortalRequestNumber { get; set; }

        public string PortalRequestEncId { get; set; }

        public string RequestStudyEncId { get; set; }

        public string Name { get; set; }

        public string IdNumber { get; set; }

        public string CodeComUtilityTexts { get; set; }

        public bool IsElectronic { get; set; }

        #endregion
    }
}
