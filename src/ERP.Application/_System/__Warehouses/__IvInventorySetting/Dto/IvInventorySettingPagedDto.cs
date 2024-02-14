using Abp.Application.Services.Dto;
namespace ERP._System.__Warehouses.__IvInventorySetting.Dto
{
  public  class IvInventorySettingPagedDto : PagedAndSortedResultRequestDto
    {
        public IvInventorySettingSearchDto Params { get; set; }
    }
}
