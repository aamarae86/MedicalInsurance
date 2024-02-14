using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxes.Dto
{
    [AutoMapFrom(typeof(TmCharityBoxes))]
    public class PagedTmCharityBoxesResultRequestDto : PagedAndSortedResultRequestDto
    {
        public TmCharityBoxesSearchDto Params { get; set; }
    }
}
