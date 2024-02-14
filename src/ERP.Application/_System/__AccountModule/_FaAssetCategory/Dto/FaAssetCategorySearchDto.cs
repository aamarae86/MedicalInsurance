using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._FaAssetCategory.Dto
{
    public class FaAssetCategorySearchDto
    {
        public string AssetCategoryNumber { get; set; }
        public string AssetCategoryNameAr { get; set; }
        public string AssetCategoryNameEn { get; set; }
        public override string ToString() => $"Params.AssetCategoryNumber={AssetCategoryNumber}&Params.AssetCategoryNameAr={AssetCategoryNameAr}&Params.AssetCategoryNameEn={AssetCategoryNameEn}";
    }
}
