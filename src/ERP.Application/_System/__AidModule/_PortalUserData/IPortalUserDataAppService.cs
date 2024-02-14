using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._Portal.UserAttachments;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP._System.__AidModule._PortalUserData.Dto;
using ERP._System.__AidModule._PortalUserUnified.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._PortalUserData
{
    public interface IPortalUserDataAppService : IAsyncCrudAppService<PortalUserDataDto, long, PortalUserUnifiedPagedDto, PortalUserDataCreateDto, PortalUserDataEditDto>
    {
        Task<PortalUserDataDto> CreateMaster(PortalUserDataCreateDto input);

        Task<List<PortalUserIncomesDto>> GetAllIncomesDetails(EntityDto<long> input);

        Task<List<PortalUserDutiesDto>> GetAllDutiesDetails(EntityDto<long> input);

        Task<List<PortalUserAttachmentsDto>> GetAllAttachments(EntityDto<long> input);

        Task<PortalUserDataDto> GetPortalUserInfo(EntityDto<long> input);

        Task<Select2PagedResult> GetPortalUnfiedUsersForUsersDataSelect2(int tenantId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
