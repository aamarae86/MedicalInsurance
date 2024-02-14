using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__Warehouses._IvItemsTypesConfigure.Dto;
using ERP._System._GlAccounts.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure
{
    public interface IIvItemsTypesConfigureAppService : IAsyncCrudAppService<IvItemsTypesConfigureDto, long, IvItemsTypesConfigurePagedDto, IvItemsTypesConfigureCreateDto, IvItemsTypesConfigureEditDto>
    {
        Task<List<CustomTreeReturn>> GetItemsTree(long id, string lang = "ar-EG");

        Task<Select2PagedResult> GetIvItemsTypesConfigureSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<IvItemsTypesConfigureDto> GetDetailAsync(EntityDto<long> input);

        Task<bool> GetExistConfigureCodeAsync(string input, long Id);

        Task<bool> GetExistNameArAsync(string input, long Id);

        Task<bool> GetExistNameEnAsync(string input, long Id);

        Task<Select2PagedResult> GetIvItemsTypesConfigureWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
       
    }
}
