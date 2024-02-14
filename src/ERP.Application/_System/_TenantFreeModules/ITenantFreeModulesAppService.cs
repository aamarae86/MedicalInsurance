using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._Modules.Dto;
using ERP._System._TenantFreeModules.Dto;
using ERP._System.TenantFreeModulesInput.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._TenantFreeModules
{
    public interface ITenantFreeModulesAppService : IAsyncCrudAppService<TenantFreeModulesDto, long, TenantFreeModulesPagedDto, TenantFreeModulesInputDto, TenantFreeModulesInputDto>
    {
        Task<TenantModuleDto> GetAppModules(EntityDto<long> input);
        Task<TenantModuleDto> GetTenantAppModules(EntityDto<long> input);
    }
}
 