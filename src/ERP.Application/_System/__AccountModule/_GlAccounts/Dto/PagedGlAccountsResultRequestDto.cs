using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccounts.Dto
{
    [AutoMapFrom(typeof(GlAccounts))]
    public class PagedGlAccountsResultRequestDto : PagedResultRequestDto
    {
        public GlAccountsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
