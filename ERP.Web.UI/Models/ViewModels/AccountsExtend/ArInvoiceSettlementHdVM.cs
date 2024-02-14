using ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto;
using ERP._System._ArCustomers;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.AccountsExtend;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.AccountsExtend
{
    public class ArInvoiceSettlementHdVM : BaseAuditedEntityVM<long>
    {
        #region ArInvoiceSettlementHd
        public string EncId { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.SettlementDate), ResourceType = typeof(ArInvoiceSettlementHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string SettlementDate { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.StatusLkpId), ResourceType = typeof(ArInvoiceSettlementHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.SettlementAmount), ResourceType = typeof(ArInvoiceSettlementHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public decimal SettlementAmount { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.SettlementNumber), ResourceType = typeof(ArInvoiceSettlementHd))]
        public string SettlementNumber { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.ArCustomerId), ResourceType = typeof(ArInvoiceSettlementHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ArCustomerId { get; set; }

        [Display(Name = nameof(ArInvoiceSettlementHd.Description), ResourceType = typeof(ArInvoiceSettlementHd))]
        public string Description { get; set; }
        public int TenantId { get; set; }
        #endregion
        #region ArInvoiceSettlementCr
        [Display(Name = nameof(ArInvoiceSettlementHd.CrSourceLkpId), ResourceType = typeof(ArInvoiceSettlementHd))]
        public long CrSourceLkpId { get; set; }
        [Display(Name = nameof(ArInvoiceSettlementHd.CrSourceId), ResourceType = typeof(ArInvoiceSettlementHd))]
        public long CrSourceId { get; set; }
        public string ArInvoiceSettlementCrStr { get; set; }
        public ICollection<ArInvoiceSettlementCrDto> ArInvoiceSettlementCr => string.IsNullOrEmpty(ArInvoiceSettlementCrStr) ?
           new List<ArInvoiceSettlementCrDto>() : Helper<List<ArInvoiceSettlementCrDto>>.Convert(ArInvoiceSettlementCrStr);

        #endregion
        #region ArInvoiceSettlementDr
        [Display(Name = nameof(ArInvoiceSettlementHd.DrSourceLkpId), ResourceType = typeof(ArInvoiceSettlementHd))]
        public long DrSourceLkpId { get; set; }
        [Display(Name = nameof(ArInvoiceSettlementHd.DrSourceId), ResourceType = typeof(ArInvoiceSettlementHd))]
        public long DrSourceId { get; set; }

        public string ArInvoiceSettlementDrStr { get; set; }

        public ICollection<ArInvoiceSettlementDrDto> ArInvoiceSettlementDr => string.IsNullOrEmpty(ArInvoiceSettlementDrStr) ?
           new List<ArInvoiceSettlementDrDto>() : Helper<List<ArInvoiceSettlementDrDto>>.Convert(ArInvoiceSettlementDrStr);
        #endregion
        public long ArInvoiceSettlementHdId { get; set; }
        public ArCustomersVM ArCustomers { get;  set; }
        public FndLookupValuesVM FndStatusLkp { get;  set; }
    }
}