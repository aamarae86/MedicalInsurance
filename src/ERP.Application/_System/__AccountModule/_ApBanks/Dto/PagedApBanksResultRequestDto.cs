using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApBanks.Dto
{
    [AutoMapFrom(typeof(ApBanks))]
    public class PagedApBanksResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ApBanksSearchDto Params { get; set; }

        public SortModel OrderByValue { get ; set ; }
    }
}
