using Abp.Application.Services;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpBeneficent
{
    public interface ISpBeneficentAppService : IAsyncCrudAppService<SpBeneficentDto, long, SpBeneficentPagedDto, SpBeneficentCreateDto, SpBeneficentEditDto>
    {

        Task<SpBeneficentDto> CreateShortCut(SpBeneficentCreateDto input);

        Task<Select2PagedResult> GetSpBeneficentNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpBeneficentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long BenefId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
