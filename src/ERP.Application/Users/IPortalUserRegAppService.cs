using Abp.Application.Services;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using System.Threading.Tasks;

namespace ERP.Users
{
    public interface IPortalUserRegAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserEditDto>
    {
        Task<Select2PagedResult> GetPortalUnfiedUsersForRegisterToPortalSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
