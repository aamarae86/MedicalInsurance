using ERP.Helpers.Parameters;
using ERP.ResourcePack.Accounts;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArSecurityDepositInterfaceVM : BaseAuditedEntityVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        [Display(Name = nameof(ArSecurityDepositInterface.CustomerNumber), ResourceType = typeof(ArSecurityDepositInterface))]
        public string CustomerNumber { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.SourceNumber), ResourceType = typeof(ArSecurityDepositInterface))]
        public string SourceNo { get; set; }

        [MaxLength(30)]
        [Display(Name = nameof(ArSecurityDepositInterface.SecurityDepositInterfaceNumber), ResourceType = typeof(ArSecurityDepositInterface))]
        public string SecurityDepositInterfaceNumber { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.Amount), ResourceType = typeof(ArSecurityDepositInterface))]
        public decimal? Amount { get; set; }

        [MaxLength(4000)]
        [Display(Name = nameof(ArSecurityDepositInterface.Notes), ResourceType = typeof(ArSecurityDepositInterface))]
        public string Notes { get; set; }


        [Display(Name = nameof(ArSecurityDepositInterface.StatusLkpId), ResourceType = typeof(ArSecurityDepositInterface))]
        public long? StatusLkpId { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.ArCustomerId), ResourceType = typeof(ArSecurityDepositInterface))]
        public long? ArCustomerId { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.SourceCodeLkpId), ResourceType = typeof(ArSecurityDepositInterface))]
        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.FromDate), ResourceType = typeof(ArSecurityDepositInterface))]
        public string FromDate { get; set; }

        [Display(Name = nameof(ArSecurityDepositInterface.ToDate), ResourceType = typeof(ArSecurityDepositInterface))]
        public string ToDate { get; set; }

        public ArCustomersVM ArCustomers { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }

        public FndLookupValuesVM FndSourceCodeLkp { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
    }
}