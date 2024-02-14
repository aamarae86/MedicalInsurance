using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._ArCustomers.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArCustomers
{
    public interface IArCustomersAppService : IAsyncCrudAppService<ArCustomersDto, long, PagedArCustomersResultRequestDto, CreateArCustomersDto, ArCustomersEditDto>
    {

        Task<Select2PagedResult> GetArCustomersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetArCustomersBytypeSelect2(string searchTerm, string lang,bool IsCash, int pageSize, int pageNumber);
        Task<ArCustomersDto> GetDetailAsync(EntityDto<long> input);
        Task<bool> GetExistCustomerNameArAsync(string input, string Id);
        Task<bool> GetExistCustomerNameEnAsync(string input, string Id);
        Task<List<ArCustomersDto>> GetAAsync();

        void SetGetAllPermissionName(string permissionName);
        void SetCreatePermissionName(string permissionName);
        void SetUpdatePermissionName(string permissionName);
        void SetDeletePermissionName(string permissionName);
        Task<Select2PagedResult> GetPOSCustomersBytypeSelect2(string searchTerm, string lang, bool IsCash, int pageSize, int pageNumber);
    }
}
