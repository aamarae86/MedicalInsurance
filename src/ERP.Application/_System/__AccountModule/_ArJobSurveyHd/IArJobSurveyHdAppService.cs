using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArJobSurveyHd.Dto;
using ERP._System._ArJobSurveyHd.Dto;
using ERP._System._ArDrCrTr.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArJobSurveyHd
{
    public interface IArJobSurveyHdAppService : IAsyncCrudAppService<ArJobSurveyHdDto, long, PagedArJobSurveyHdResultRequestDto, CreateArJobSurveyHdDto, ArJobSurveyHdEditDto>
    {
        Task<ArJobSurveyHdDto> GetDetailAsync(EntityDto<long> input);

       // Task<PostOutput> PostArJobSurveyHd(PostDto postDto);
    }
}
