using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccDetails.Dto
{

    [AutoMapFrom(typeof(GlAccDetails))]
    public class PagedGlAccDetailsResultRequestDto: PagedResultRequestDto
    {
        public GlAccDetailsSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }

    }
}
