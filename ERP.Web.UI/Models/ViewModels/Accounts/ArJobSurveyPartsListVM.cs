using ERP.Core.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArJobSurveyPartsListVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyPartsList.PartsNumber), ResourceType = typeof(ArJobSurveyPartsList))]
        public string PartsNumber { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyPartsList.PartsName), ResourceType = typeof(ArJobSurveyPartsList))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PartsName { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyPartsList.PartsCategoryLkpId), ResourceType = typeof(ArJobSurveyPartsList))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long PartsCategoryLkpId { get; set; }
        public FndLookupValuesVM PartsCategoryLkp { get; set; }
    }
}
