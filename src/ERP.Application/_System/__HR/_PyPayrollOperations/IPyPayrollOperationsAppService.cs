using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._PyPayrollOperations.Dto;
using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollOperations
{
    public interface IPyPayrollOperationsAppService
        : IAsyncCrudAppService<PyPayrollOperationsDto, long, PyPayrollOperationsPagedDto, PyPayrollOperationsCreateDto, PyPayrollOperationsEditDto>
    {
        Task<PyPayrollOperationsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<PyPayrollOperationPersonsDto>> GetAllPyPayrollOperationsPersons(EntityDto<long> input);

        Task<Select2PagedResult> GetPersonsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPersonsJobsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PostOutput> PostPyPayrollOperations(StoredInput idLangInputDto);

        Task<PostOutput> ApprovalPyPayrollOperations(StoredInput idLangInputDto);

        Task<PostOutput> UnApprovedPyPayrollOperations(StoredInput idLangInputDto);
    }
}
