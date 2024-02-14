using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArCustomersVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(ArCustomers.CustomerNumber), ResourceType = typeof(ArCustomers))]
        public int CustomerNumber { get; set; }

        public string Source { get; set; }

        [Display(Name = nameof(ArCustomers.NameAr), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsCustomerNameAr", "ArCustomers", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string CustomerNameAr { get; set; }

        [Display(Name = nameof(ArCustomers.NameEn), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [MaxLength(200)]
        [Remote("CheckIsExistsCustomerNameEn", "ArCustomers", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "nameExist", ErrorMessageResourceType = typeof(Settings))]
        public string CustomerNameEn { get; set; }

        [Display(Name = nameof(ArCustomers.Status), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.CreditLimit), ResourceType = typeof(ArCustomers))]
        public decimal? CreditLimit { get; set; }

        [Display(Name = nameof(ArCustomers.CustomerType), ResourceType = typeof(ArCustomers))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        [Remote("CheckCustomerTypeIsAlreadyExist", "ArCustomers", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessageResourceName = "AlreadyAssigned", ErrorMessageResourceType = typeof(Settings))]
        public long CustomerTypeLkpId { get; set; }

        [Display(Name = nameof(ArCustomers.Address), ResourceType = typeof(ArCustomers))]
        [MaxLength(4000)]
        public string Address { get; set; }

        [Display(Name = nameof(ArCustomers.HomeTel), ResourceType = typeof(ArCustomers))]
        [MaxLength(50)]
        public string HomeTel { get; set; }

        [Display(Name = nameof(ArCustomers.WorkTel), ResourceType = typeof(ArCustomers))]
        [MaxLength(50)]
        public string WorkTel { get; set; }

        [Display(Name = nameof(ArCustomers.Mobile), ResourceType = typeof(ArCustomers))]
        [MaxLength(50)]
        public string Mobile { get; set; }

        [Display(Name = nameof(ArCustomers.Fax), ResourceType = typeof(ArCustomers))]
        [MaxLength(50)]
        public string Fax { get; set; }

        [Display(Name = nameof(ArCustomers.Email), ResourceType = typeof(ArCustomers))]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = nameof(ArCustomers.Website), ResourceType = typeof(ArCustomers))]
        [MaxLength(200)]
        public string Website { get; set; }

        [Display(Name = nameof(ArCustomers.TaxNo), ResourceType = typeof(ArCustomers))]
        public string TaxNo { get; set; }
        
        public long? PaymentTermsLkpId { get; set; }
        public FndLookupValuesVM FndLookupValues { get; set; }

        public FndLookupValuesVM FndLookupValuesCustType { get; set; }

        public FndLookupValuesVM FndLookupValuesSource { get; set; }
        public FndLookupValuesVM FndPaymentTermsLkp { get; set; }

        [Display(Name = nameof(Settings.Source), ResourceType = typeof(Settings))]
        public long SourceCodeLkpId { get; set; }

        public string Lang { get; set; }
    }
}