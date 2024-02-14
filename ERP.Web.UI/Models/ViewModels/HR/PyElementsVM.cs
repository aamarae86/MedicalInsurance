using ERP.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class PyElementsVM : BaseAuditedEntityVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote("CheckIsExistsElementSerial", "PyElements", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "ElementSerialExist", ErrorMessageResourceType = typeof(PyElements))]
        [Display(Name = nameof(PyElements.ElementSerial), ResourceType = typeof(PyElements))]
        public int ElementSerial { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote("CheckIsExistsElementName", "PyElements", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "ElementNameExist", ErrorMessageResourceType = typeof(PyElements))]
        [Display(Name = nameof(PyElements.ElementName), ResourceType = typeof(PyElements))]
        public string ElementName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Display(Name = nameof(PyElements.ElementTypeLkpId), ResourceType = typeof(PyElements))]
        public long ElementTypeLkpId { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(PyElements.Description), ResourceType = typeof(PyElements))]
        public string Description { get; set; }

        [Display(Name = nameof(PyElements.DebitAccountId), ResourceType = typeof(PyElements))]
        public long? DebitAccountId { get; set; }

        public string Lang { get; set; }

        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds { get; set; }

        public FndLookupValuesVM FndLookupValuesElementTypeLkp { get; set; }

    }
}