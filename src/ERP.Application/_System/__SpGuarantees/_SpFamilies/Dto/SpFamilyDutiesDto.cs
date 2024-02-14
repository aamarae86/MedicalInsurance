using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpFamilyDuties;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    [AutoMap(typeof(SpFamilyDuties))]
    public class SpFamilyDutiesDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpFamilyId { get; set; }

        public string DutyType { get; set; }

        public string DutyDescription { get; set; }

        public decimal MonthlyAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public string rowStatus { get; set; }
    }
}
