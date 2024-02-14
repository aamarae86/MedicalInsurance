using ERP.ResourcePack.CharityBoxes;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.CharityBoxes
{
    public class TmCharityBoxReceiveVM : BasePostAuditedVM<long>
    {
        [Display(Name = nameof(TmCharityBoxReceive.ReceiveDate), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ReceiveDate { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.ReceiveDateFrom), ResourceType = typeof(TmCharityBoxReceive))]
        public string ReceiveDateFrom { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.ReceiveDateTo), ResourceType = typeof(TmCharityBoxReceive))]
        public string ReceiveDateTo { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.ReceiveNumber), ResourceType = typeof(TmCharityBoxReceive))]
        public string ReceiveNumber { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.StatusLkpId), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }
        public FndLookupValuesVM FndLookupValues { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.SupplierName), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        public string SupplierName { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.CharityTypeId), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long CharityTypeId { get; set; }
        public TmCharityBoxesTypeVM CharityBoxesType { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.NoOfCharityBox), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long NoOfCharityBox { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.AmountCharityBox), ResourceType = typeof(TmCharityBoxReceive))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal AmountCharityBox { get; set; }

        [Display(Name = nameof(TmCharityBoxReceive.Notes), ResourceType = typeof(TmCharityBoxReceive))]
        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}