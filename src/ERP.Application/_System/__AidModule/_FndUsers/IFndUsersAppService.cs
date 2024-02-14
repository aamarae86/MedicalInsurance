using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._FndUserRelatives.Dto;
using ERP._System.__AidModule._FndUsers.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._FndUsers
{
    public interface IFndUsersAppService:
                IAsyncCrudAppService<FndUsersDto, long, PagedFndUsersResultRequestDto, CreateFndUsersDto, FndUsersDto>
    {
        Task<FndUsersDto> GetDetailAsync(EntityDto<long> input);

        Task<List<FndUserRelativesDto>> GetAllDetails(long id);

        Task<Select2PagedResult> GetFndUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
