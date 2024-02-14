using Abp.AutoMapper;
using ERP._System.__Warehouses._IvItems;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvPriceListHd.Dto
{
    [AutoMap(typeof(IvPriceListHd))]
    public class IvPriceListHdDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
       
        [MaxLength(20)]
        public string PriceListNumber { get; set; }

        [Required]
        [MaxLength(200)]
        public string PriceListName { get; set; }

        public IvItems Items { get; set; }
        public ICollection<IvPriceListTrDto> PriceListDetails { get; set; }


    }
}
