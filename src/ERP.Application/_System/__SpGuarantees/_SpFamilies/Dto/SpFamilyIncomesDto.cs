using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpFamilyIncomes;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    [AutoMap(typeof(SpFamilyIncomes))]
    public class SpFamilyIncomesDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpFamilyId { get;  set; }

        public string IncomeSourceName { get;  set; }

        public decimal MonthlyIncomeAmount { get;  set; }

        public string rowStatus { get; set; }
    }
}
