using Abp.Application.Services;
using ERP._System.__SpGuarantees._SpCaseHistory.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseHistory
{
    public interface ISpCaseHistoryAppService : IApplicationService
    {
        Task<List<SpCaseHistoryDto>> GetSpCaseHistory(long caseId);
    }
}
