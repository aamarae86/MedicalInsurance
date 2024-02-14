using ERP._System._ArInvoiceTr.Dto;
using ERP.Front.Helpers.Core;
using ERP.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArJobSurveyTrVM : BasePostAuditedVM<long>, IDetailRowStatus
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public long? ArJobSurveyHdId { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ArJobSurveyPartsId), ResourceType = typeof(ArJobSurveyHd))]
        public long? ArJobSurveyPartsId { get; set; }
        // public string SurveyPartsName { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.PartsCategoryLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? PartsCategoryLkpId { get; set; }
       // public string PartsCategoryName { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
        public string rowStatus { get; set; }
    }
}