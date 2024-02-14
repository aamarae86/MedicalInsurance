using Abp.Application.Services;
using ERP._System.__HR._HrPaperRequest.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest
{
    public interface IHrPaperRequestAppService : IAsyncCrudAppService<HrPaperRequestDto, long, HrPaperRequestPagedDto, HrPaperRequestCreateDto, HrPaperRequestEditDto>
    {
    }
}
