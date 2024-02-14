using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
  public class IvInventorySettingPriceListDto : EntityDto<long>, IDetailRowStatus
    {
        public long IvInventorySettingId { get;  set; }
        public long IvPriceListHdId { get;  set; }
        public string PriceListName { get; set; }
        public string rowStatus { get; set; }
    }
}
