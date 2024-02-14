using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonsDeductionHdDeduction
{
    public interface IHrPersonsDeductionHdAppService : IAsyncCrudAppService<HrPersonsDeductionHdDto, long, HrPersonsDeductionHdPagedDto, HrPersonsDeductionHdCreateDto, HrPersonsDeductionHdEditDto>
    {
        Task<HrPersonsDeductionHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<HrPersonsDeductionTrDto>> GetAllDeductionDetails(EntityDto<long> input);

        Task<PostRecords.Dto.PostOutput> PostHrPersonsDeduction(PostRecords.Dto.PostDto postDto);
    }
}
