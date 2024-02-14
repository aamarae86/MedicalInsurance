using ERP._System.__Warehouses._IvStoreIssue.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Warehouses;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Warehouses
{
    public class IvStoreIssueVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        #region Search Params
        [Display(Name = nameof(IvStoreIssue.IvStoreIssueDate), ResourceType = typeof(IvStoreIssue))]
        public DateTime? Search_IvStoreIssueDate { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvStoreIssueNumber), ResourceType = typeof(IvStoreIssue))]
        public string Search_IvStoreIssueNumber { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvWarehouseId), ResourceType = typeof(IvStoreIssue))]
        public long? Search_IvWarehouseId { get; set; }
        [Display(Name = nameof(IvStoreIssue.StatusLkpId), ResourceType = typeof(IvStoreIssue))]
        public long? Search_StatusId { get; set; }
        #endregion

        #region Master Properties
        [Display(Name = nameof(IvStoreIssue.IvStoreIssueDate), ResourceType = typeof(IvStoreIssue))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StoreIssueDate { get; set; }

        [Display(Name = nameof(IvStoreIssue.StatusLkpId), ResourceType = typeof(IvStoreIssue))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }
        [Display(Name = nameof(IvStoreIssue.IssueTypeLkpId), ResourceType = typeof(IvStoreIssue))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IssueTypeLkpId { get; set; }
        [Display(Name = nameof(IvStoreIssue.ManualNo), ResourceType = typeof(IvStoreIssue))]
        public string ManualNo { get; set; }
        [Display(Name = nameof(IvStoreIssue.BeneficiaryTypeLkpId), ResourceType = typeof(IvStoreIssue))]
        public long BeneficiaryTypeLkpId { get; set; }
        [Display(Name = nameof(IvStoreIssue.BeneficiaryName), ResourceType = typeof(IvStoreIssue))]
        public string BeneficiaryName { get; set; }
        [Display(Name = nameof(IvStoreIssue.Comment), ResourceType = typeof(IvStoreIssue))]
        public string Comment { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvWarehouseId), ResourceType = typeof(IvStoreIssue))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long IvWarehouseId { get; set; }

        #endregion

        #region Master Mapped Properties
        [Display(Name = nameof(IvStoreIssue.IvStoreIssueNumber), ResourceType = typeof(IvStoreIssue))]
        public string StoreIssueNumber { get; set; }
        public string IvWarehouseName { get; set; }
        public string StatusEn { get; set; }
        public string StatusAr { get; set; }
        public string BeneficiaryTypeEn { get; set; }
        public string BeneficiaryTypeAr { get; set; }
        public string IssueTypeEn { get; set; }
        public string IssueTypeAr { get; set; }

        public string Status => IvStoreIssue.NewStatus;
        #endregion

        #region Detail Properties
        [Display(Name = nameof(IvStoreIssue.IvItemNumber), ResourceType = typeof(IvStoreIssue))]
        public string IvItemNumber { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvItemId), ResourceType = typeof(IvStoreIssue))]
        public long? IvItemId { get; set; }
        [Display(Name = nameof(IvStoreIssue.Qty), ResourceType = typeof(IvStoreIssue))]
        public decimal Qty { get; set; }
        [Display(Name = nameof(IvStoreIssue.AvgCost), ResourceType = typeof(IvStoreIssue))]
        public decimal AvgCost { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvUnitId), ResourceType = typeof(IvStoreIssue))]
        public long? IvUnitId { get; set; }
        [Display(Name = nameof(IvStoreIssue.IvUnitId), ResourceType = typeof(IvStoreIssue))]
        public string IvUnitName { get; set; }
        [Display(Name = nameof(IvStoreIssue.Total), ResourceType = typeof(IvStoreIssue))]
        public decimal? Total { get; set; }
        /*
IvStoreIssueHdId bigint NOT NULL, with master
*/
        #endregion

        #region Detail Listings
        public string ListIvStoreIssueDetails { get; set; }

        public virtual ICollection<IvStoreIssueDetailsCreateDto> ListOfDetails { get; set; }

        public virtual ICollection<IvStoreIssueDetailsEditDto> ListOfEditDetails { get; set; }

        public virtual ICollection<IvStoreIssueDetailsCreateDto> ListOfCreateDetails { get; set; }
        #endregion

        #region CodeCom
        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
        #endregion
    }
}