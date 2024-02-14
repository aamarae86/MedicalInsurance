using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApVendors
{
    public interface IApVendorsAppService : IAsyncCrudAppService<ApVendorsDto, long, PagedApVendorsResultRequestDto, ApVendorsCreateDto, ApVendorsEditDto>
    {
        Task<ApVendorsDto> GetDetailAsync(EntityDto<long> input);

        Task<bool> GetExistVendorNameArAsync(string input, string Id);

        Task<bool> GetExistVendorNameEnAsync(string input, string Id);

        Task<Select2PagedResult> GetVendorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
