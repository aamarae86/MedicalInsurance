using Abp.Application.Services;
using ERP.MultiTenancy.Dto;
using System.Threading.Tasks;

namespace ERP._System._AdminMyTenant
{
    public interface ITenantData : IApplicationService
    {
        Task<TenantDetailEditDto> GetTenantDetailDto();
        Task<bool> PostTenantDetailDto(TenantDetailEditDto tenantDetailDto);
    }
}
