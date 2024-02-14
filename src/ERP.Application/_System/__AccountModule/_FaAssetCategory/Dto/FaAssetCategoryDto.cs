using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AccountModule._FaAssetCategory.Dto
{
    [AutoMap(typeof(FaAssetCategory))]
    public class FaAssetCategoryDto : AuditedEntityDto<long>, IEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [MaxLength(30)]
        public string AssetCategoryNumber { get;  set; }
        [MaxLength(200)]
        public string AssetCategoryNameAr { get;  set; }
        [MaxLength(200)]
        public string AssetCategoryNameEn { get;  set; }
        [MaxLength]
        public string Description { get;  set; }
        public long? NoMonthsDepreciation { get;  set; }

        public long? AssetCostAccountId { get;  set; }
        public long? AssetClearingAccountId { get;  set; }
        public long? AccDeprenAccountId { get;  set; }
        public long? DeprenAccountId { get;  set; }

        public GlCodeComDetailsDto GlCodeComDetailsAssetCostAccount { get;  set; }

        public GlCodeComDetailsDto GlCodeComDetailsAssetClearingAccount { get;  set; }

        public GlCodeComDetailsDto GlCodeComDetailsAccDeprenAccount { get;  set; }

        public GlCodeComDetailsDto GlCodeComDetailsDeprenAccount { get;  set; }

        public string codeComUtilityIds { get ; set ; }
        public string codeComUtilityTexts { get ; set ; }

        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }

        public string codeComUtilityIds_alt2 { get; set; }
        public string codeComUtilityTexts_alt2 { get; set; }

        public string codeComUtilityIds_alt3 { get; set; }
        public string codeComUtilityTexts_alt3 { get; set; }
    }
}
