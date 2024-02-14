using ERP._System.__Warehouses._IvPriceListHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvPriceListHdVM : BasePostAuditedVM<long>
    {
        public string EncId { get; set; }

        [MaxLength(20)]
        [Display(Name = nameof(IvPriceListHd.PriceListNumber), ResourceType = typeof(IvPriceListHd))]
        public string PriceListNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(IvPriceListHd.PriceListName), ResourceType = typeof(IvPriceListHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PriceListName { get; set; }

      


        #region details
        [Display(Name = nameof(IvPriceListHd.ItemNo), ResourceType = typeof(IvPriceListHd))]
        public long IvItemId { get; set; }
        [Display(Name = nameof(IvPriceListHd.ItemName), ResourceType = typeof(IvPriceListHd))]
        public string ItemName { get; set; }
        [Display(Name = nameof(IvPriceListHd.Price), ResourceType = typeof(IvPriceListHd))]
        public decimal Price { get; set; }
         public IvItemsVM Items { get; set; }
        #endregion
        public string PriceListDetailsListStr { get; set; }
        [Display(Name = nameof(IvPriceListHd.Percentage), ResourceType = typeof(IvPriceListHd))]
        public decimal Percentage { get; set; }
        [Display(Name = nameof(IvPriceListHd.AllOrganization), ResourceType = typeof(IvPriceListHd))]
        public bool AllOrganization { get; set; }
        [Display(Name = nameof(IvPriceListHd.IvItemsTypesConfigureId), ResourceType = typeof(IvPriceListHd))]
        public long IvItemsTypesConfigureId { get; set; }
        public ICollection<IvPriceListTrDto> PriceListDetails => string.IsNullOrEmpty(PriceListDetailsListStr) ?
                new List<IvPriceListTrDto>() : Helper<List<IvPriceListTrDto>>.Convert(PriceListDetailsListStr);

       

    }
}