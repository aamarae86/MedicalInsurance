using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlMainAccounts.Dto
{
    public class PagedGlMainAccountsResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public GlMainAccountsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
