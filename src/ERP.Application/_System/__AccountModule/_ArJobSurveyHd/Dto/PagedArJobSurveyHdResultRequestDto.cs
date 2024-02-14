using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArJobSurveyHd.Dto
{
    public class PagedArJobSurveyHdResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArJobSurveyHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
