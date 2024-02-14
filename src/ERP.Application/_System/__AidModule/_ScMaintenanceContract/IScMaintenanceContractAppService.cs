using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    public interface IScMaintenanceContractAppService : IAsyncCrudAppService<ScMaintenanceContractDto, long, ScMaintenanceContractPagedDto, ScMaintenanceContractCreateDto, ScMaintenanceContractEditDto>
    {
        Task<PostOutput> PostScMaintenanceContract(PostDto postDto);

        Task<IReadOnlyList<ScMaintenanceContractPaymentsDto>> GetAllPaymentsData(EntityDto<long> input);

        Task<Select2PagedResult> GetScMaintenanceContractPaymentsByContractNumberSelect2(string contractNumber, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScMaintenanceQuotationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScMaintenanceContractPaymentsSelect2(long contractId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetScMaintenanceContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
