using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndAidRequestType
{
    public interface IScFndAidRequestTypeAppService : IAsyncCrudAppService<ScFndAidRequestTypeDto, long, PagedScFndAidRequestTypeResultRequestDto, CreateScFndAidRequestTypeDto, ScFndAidRequestTypeEditDto>
    {
        Task<ScFndAidRequestTypeDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetAidRequestTypeLkp(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetAidRequestTypeLkpForTenant(int tenantId, string lang);
    }
}
