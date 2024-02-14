using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCaseOperations.Dto;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseOperations
{
    public interface ISpCaseOperationsAppService : IApplicationService
    {
        Task<IEnumerable<SpCaseOperationsDataDto>> GetSpCasesContractDetails(SpCaseOperationsSearchDto dto);

        // def : (turn off ,cancelation)
        Task<PostOutput> OperateCase(SpCaseOperationsInputDto inputDto);

        Task<PostOutput> OperateReplaceCase(SpCaseOperationsReplaceInputDtoHelper inputDto);

        Task<SpCaseOperationsDataDto> Get(EntityDto<long> input);
    }
}
