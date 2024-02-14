using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScPortalRequest.Dto;
using ERP._System.__AidModule._ScPortalRequestVisited.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public interface IScPortalRequestAppService : IAsyncCrudAppService<ScPortalRequestDto, long, ScPortalRequestPagedDto, ScPortalRequestCreateDto, ScPortalRequestEditDto>
    {
        Task<ScPortalRequestDto> PortalCreate(ScPortalRequestCreateDto input);

        Task<ScPortalRequestDto> PortalUpdate(ScPortalRequestEditDto input);

        Task PortalDelete(EntityDto<long> input, int TenantId);

        Task<ScPortalRequestDto> PortalGet(EntityDto<long> input, int TenantId);

        Task<PagedResultDto<ScPortalRequestDto>> PortalGetAll(ScPortalRequestPagedDto input);

        Task<Select2PagedResult> GetScPortalRequestSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScPortalRequestMaintenanceSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScPortalRequestForMgrSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScPortalRequestForStudySelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<ScPortalRequestDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ScPortalRequestVisitedDto>> GetAllVisitsDetails(long id);

        Task<List<ScPortalRequestAttachmentDto>> GetAllAttachmentsDetails(long id, long aidRequestId);

        Task<PostOutput> PostPortalRequest(PostDto postDto);

        Task<PostOutput> RefusePortalRequest(PostDto postDto);

        Task<PostOutput> UnPostScPortalRequests(PostDto postDto);

        Task<List<ScPortalRequestIncomeDto>> GetAllIncomesDetails(EntityDto<long> input);

        Task<List<ScPortalRequestDutiesDto>> GetAllDutiesDetails(EntityDto<long> input);
    }
}
