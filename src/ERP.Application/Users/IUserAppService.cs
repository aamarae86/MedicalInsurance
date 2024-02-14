using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP.Helpers.Core;
using ERP.Roles.Dto;
using ERP.Users.Dto;

namespace ERP.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserEditDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<Select2PagedResult> GetUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PortalUserUnifiedDto> SignUp(PortalUserUnifiedCreateDto input);
    }
}
