using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto
{
    public class PagedArJobSurveyPartsListResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArJobSurveyPartsListSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
