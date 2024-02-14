using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._GlMainAccounts.Dto;
using ERP._System._GlMainAccounts.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._GlMainAccounts
{
    public interface IGlMainAccountsAppService : IAsyncCrudAppService<GlMainAccountsDto, long, PagedGlMainAccountsResultRequestDto, CreateGlMainAccountsDto, GlMainAccountsEditDto>
    {

        Task<Select2PagedResult> GetGlMainAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<GlMainAccountsDto> GetDetailAsync(EntityDto<long> input);

    }
}
