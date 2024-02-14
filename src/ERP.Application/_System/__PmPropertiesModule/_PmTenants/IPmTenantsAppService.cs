using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmTenants.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmTenants
{
    public interface IPmTenantsAppService : IAsyncCrudAppService<PmTenantsDto, long, PagedPmTenantsResultRequestDto, PmTenantsCreateDto, PmTenantsEditDto>
    {
        Task<PmTenantsDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetPmTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPmTenantsNameAndIdNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
