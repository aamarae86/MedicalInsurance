using Abp.AutoMapper;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    [AutoMap(typeof(FaAssetDeprnHd))]
    public class FaAssetDeprnHdDto : FaAssetDeprnHdBaseWithLookupsDto
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public long? StatusLkpId { get; set; }

        [MaxLength(30)]
        public string AssetDeprnNumber { get; set; }
    }
}
