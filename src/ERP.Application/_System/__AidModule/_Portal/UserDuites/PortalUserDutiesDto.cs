using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._Portal._PortalUserDuties;
using ERP._System.__AidModule._ScPortalRequest;
using ERP.Helpers.Core;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__AidModule._Portal.UserDuites
{
    [AutoMap(typeof(PortalUserDuties), typeof(ScPortalRequestDuties))]
    public class PortalUserDutiesDto : EntityDto<long>, IDetailRowStatus
    {
        public string DutyType { get; set; }

        public string DutyDescription { get; set; }

        public decimal MonthlyAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public long PortalUserDataId { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
