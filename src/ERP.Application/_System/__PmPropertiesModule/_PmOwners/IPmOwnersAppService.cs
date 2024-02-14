using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmOwners.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOwners
{
    public interface IPmOwnersAppService : IAsyncCrudAppService<PmOwnersDto, long, PagedPmOwnersResultRequestDto, PmOwnersCreateDto, PmOwnersEditDto>
    {
        Task<PmOwnersDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetPmOwnersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<decimal> GetOwnerActivityTaxPercentage(long ownerId,long activityLkpId);
    }

}
