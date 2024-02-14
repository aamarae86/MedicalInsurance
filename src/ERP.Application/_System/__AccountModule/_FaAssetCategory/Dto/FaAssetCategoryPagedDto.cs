using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._FaAssetCategory.Dto
{
    public class FaAssetCategoryPagedDto: PagedAndSortedResultRequestDto
    {
        public FaAssetCategorySearchDto Params { get; set; }
    }
}
