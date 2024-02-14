using Abp.Application.Services;
using ERP._System.__AidModule._PortalUserUnified.Dto;

namespace ERP._System.__AidModule._PortalUserUnified
{
    public interface IPortalUserUnifiedAppService : IAsyncCrudAppService<PortalUserUnifiedDto, long, PortalUserUnifiedPagedDto, PortalUserUnifiedCreateDto, PortalUserUnifiedEditDto>
    {
    }
}
