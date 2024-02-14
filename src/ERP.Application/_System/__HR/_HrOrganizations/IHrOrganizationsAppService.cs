using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrOrganizations.Dto;
using ERP._System._GlAccounts.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrOrganizations
{
    public interface IHrOrganizationsAppService : IAsyncCrudAppService<HrOrganizationsDto, long, HrOrganizationsPagedDto, HrOrganizationsCreateDto, HrOrganizationsEditDto>
    {
        Task<List<CustomTreeReturn>> GetHRTree(long id, string lang = "ar-EG");

        Task<Select2PagedResult> GetHrOrganizationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<HrOrganizationsDto> GetDetailAsync(EntityDto<long> input);

        Task<bool> GetExistOrganizationNameAsync(string input, long Id);

        Task<Select2PagedResult> GetHrOrganizationsWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
