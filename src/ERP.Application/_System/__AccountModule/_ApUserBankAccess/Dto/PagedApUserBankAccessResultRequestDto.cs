using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApUserBankAccess.Dto
{
    [AutoMapFrom(typeof(ApUserBankAccess))]
    public class PagedApUserBankAccessResultRequestDto : PagedResultRequestDto
    {
        public ApUserBankAccessSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
