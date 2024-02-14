using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCaseEditData.Dto;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.ProcDto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseEditData
{
    public interface ISpCaseEditDataAppService : IApplicationService
    {
        Task<IEnumerable<SpCaseEditDataDataDto>> GetSpCasesContractDetails(SpCaseEditDataSearchDto dto);

        // def : (turn off ,cancelation)
        Task<PostOutput> EditCase(SpCaseEditDataInputDto inputDto);
        Task<PostOutput> EditAllCases(SpCaseEditDataInputDto inputDto);


        Task<SpCaseEditDataDataDto> Get(EntityDto<long> input);
    }
}
