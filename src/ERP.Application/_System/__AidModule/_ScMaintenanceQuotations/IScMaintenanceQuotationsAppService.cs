using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public interface IScMaintenanceQuotationsAppService : IAsyncCrudAppService<ScMaintenanceQuotationsDto, long, ScMaintenanceQuotationsPagedDto, ScMaintenanceQuotationsCreateDto, ScMaintenanceQuotationsEditDto>
    {
        Task<PostOutput> PostScMaintenanceQuotations(PostDto postDto);

        Task<List<ScMaintenanceQuotationDetailsDto>> GetAllScMaintenanceQuotationDetailsData(EntityDto<long> input);

        Task<List<ScMaintenanceQuotationAttachmentsDto>> GetAllAttachments(EntityDto<long> input);
    }
}
