using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersonsAdditionHd.Dto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonsAdditionHd
{
    public interface IHrPersonsAdditionHdAppService : IAsyncCrudAppService<HrPersonsAdditionHdDto, long, PagedHrPersonsAdditionHdRequestDto, CreateHrPersonsAdditionHdDto, HrPersonsAdditionHdEditDto>
    {
        Task<HrPersonsAdditionHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<HrPersonsAdditionTrDto>> GetAllAdjustmentTr(EntityDto<long> input);

        Task<PostOutput> PostHrPersonsAdditionHd(PostDto postDto);

        Task<string> GetPersonNumber(EntityDto<long> input);
    }
}
