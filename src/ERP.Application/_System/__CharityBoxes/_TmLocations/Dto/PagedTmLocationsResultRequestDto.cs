using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmLocations.Dto
{
    [AutoMapFrom(typeof(TmLocations))]
    public class PagedTmLocationsResultRequestDto : PagedAndSortedResultRequestDto
    {
        public TmLocationsSearchDto Params { get; set; }
    }
}
