using Abp.Application.Services;
using ERP._System.__AccountModule._GlAccounts.ProcDto;
using ERP._System._GlAccounts.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._GlAccounts
{
    public interface IGlAccountsAppService : IAsyncCrudAppService<GlAccountDto, long, PagedGlAccountsResultRequestDto, CreateGlAccountsDto, GlAccountsEditDto>
    {
        Task<Select2PagedResult> GetGlAccountsForAccMappingSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetGlAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string filterTrigger = null);

        Task<List<CustomTreeReturn>> GetMyTreeAsync(string lang, long id);

        Task<bool> GetExistCodeAsync(string input, string Id);

        Task<bool> GetExistDescriptionArAsync(string input, string Id);

        Task<bool> GetExistDescriptionEnAsync(string input, string Id);

        Task<bool> GetGlAccountBoolAsync(long Id);

        Task<List<GlAccountsScreenDataOutput>> GetGlAccountsScreenData(GlAccountsScreenDataInput glAccountsScreenDataInput);
    }
}
