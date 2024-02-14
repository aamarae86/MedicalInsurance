using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SpGuarantees._SpFamilies.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpFamilies
{
    public interface ISpFamiliesAppService : IAsyncCrudAppService<SpFamiliesDto, long, PagedSpFamiliesResultRequestDto, SpFamiliesCreateDto, SpFamiliesEditDto>
    {
        Task<List<SpFamilyIncomesDto>> GetAllIncomesDetails(long id);

        Task<List<SpFamilyDutiesDto>> GetAllDutiesDetails(long id);

        Task<List<SpFamilyCasesDto>> GetAllCasesDetails(long id);

        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetGaurdiantSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<SpFamiliesDto> GetDetailAsync(EntityDto<long> input);

    }
}
