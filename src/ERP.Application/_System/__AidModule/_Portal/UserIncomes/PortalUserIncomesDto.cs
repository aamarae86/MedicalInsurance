using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._Portal._PortalUserIncomes;
using ERP.Helpers.Core;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__AidModule._Portal.UserIncomes
{
    [AutoMap(typeof(PortalUserIncomes))]
    public class PortalUserIncomesDto : EntityDto<long>, IDetailRowStatus
    {
        public string IncomeSourceName { get; set; }

        public decimal MonthlyIncomeAmount { get; set; }

        public long PortalUserDataId { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();

        public string Notes { get; set; }
    }
}
