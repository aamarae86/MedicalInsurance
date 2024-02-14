using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    [AutoMapFrom(typeof(TmCharityBoxReceive))]
    public class PagedTmCharityBoxReceiveResultRequestDto : PagedAndSortedResultRequestDto
    {
        public TmCharityBoxReceiveSearchDto Params { get; set; }
    }
}
