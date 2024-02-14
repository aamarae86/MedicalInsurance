using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP.Helpers.Core;
using ERP.MultiTenancy.Dto;
using System.Threading.Tasks;

namespace ERP.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
        Task<Select2PagedResult> GetTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

