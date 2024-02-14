using Abp.AutoMapper;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AccountModule._FaAssetCategory.Dto
{
    [AutoMap(typeof(FaAssetCategory))]
    public class FaAssetCategoryCreateDto: CodeComUtility
    {
        [MaxLength(30)]
        public string AssetCategoryNumber { get; set; }
        [MaxLength(200)]
        public string AssetCategoryNameAr { get; set; }
        [MaxLength(200)]
        public string AssetCategoryNameEn { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public long? NoMonthsDepreciation { get; set; }

        public long? AssetCostAccountId { get; set; }
        public long? AssetClearingAccountId { get; set; }
        public long? AccDeprenAccountId { get; set; }
        public long? DeprenAccountId { get; set; }

        public string Lang { get; set; }
    }
}
