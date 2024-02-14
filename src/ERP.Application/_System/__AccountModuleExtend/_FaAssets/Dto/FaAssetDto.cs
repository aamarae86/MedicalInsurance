using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetDto : FaAssetBaseWithLookupsDto
    {
        public string AssetNumber { get; set; }
    }
}
