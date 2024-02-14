using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GeneralUnPost.Dto
{
    [AutoMapFrom(typeof(GeneralUnPost))]
    public class PagedGeneralUnPostResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public GeneralUnPostSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
