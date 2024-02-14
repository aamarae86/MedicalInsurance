using ERP._System.__AccountModule._ArJobCardHd.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using ERP.Web.UI.Models.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArJobCardHdVM : BaseAuditedEntityVM<long>, IAttachmentListJSONString
    {
        
        public string EncId { get; set; }

        [Display(Name = nameof(ArJobCardHd.JobNumber), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string JobNumber { get; set; }

        [Display(Name = nameof(ArJobCardHd.JobDate), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string JobDate { get; set; }

        [Display(Name = nameof(ArJobCardHd.StartDate), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string StartDate { get; set; }

        [Display(Name = nameof(ArJobCardHd.EndDate), ResourceType = typeof(ArJobCardHd))]
        public string EndDate { get; set; }

        public string InvoiceDate { get; set; }
        [MaxLength(4000)]
        [Display(Name = nameof(ArJobCardHd.CloseReason), ResourceType = typeof(ArJobCardHd))]
        public string CloseReason { get; set; }

        [Display(Name = nameof(ArJobCardHd.ArCustomerId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long ArCustomerId { get; set; }

        [Display(Name = nameof(ArJobCardHd.ArCustomers), ResourceType = typeof(ArJobCardHd))]
        public ArCustomersVM ArCustomers { get;  set; }


        [MaxLength(200)]
        [Display(Name = nameof(ArJobCardHd.ContactName), ResourceType = typeof(ArJobCardHd))]
        public string ContactName { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(ArJobCardHd.ContactNo), ResourceType = typeof(ArJobCardHd))]
        public string ContactNo { get; set; }

        [Display(Name = nameof(ArJobCardHd.PoliceReportNo), ResourceType = typeof(ArJobCardHd))]
        public string PoliceReportNo { get; set; }        

        [MaxLength(50)]
        [Display(Name = nameof(ArJobCardHd.VehiclePlateNo), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string VehiclePlateNo { get; set; }

        [MaxLength(50)]
        [Display(Name = nameof(ArJobCardHd.VehicleType), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string VehicleType { get; set; }

        [Display(Name = nameof(ArJobCardHd.EstimatedAmount), ResourceType = typeof(ArJobCardHd))]
        public decimal EstimatedAmount { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(ArJobCardHd.ClaimNo), ResourceType = typeof(ArJobCardHd))]
        public string ClaimNo { get; set; }

        [MaxLength(200)]
        [Display(Name = nameof(ArJobCardHd.LpoNo), ResourceType = typeof(ArJobCardHd))]
        public string LpoNo { get; set; }

        [Display(Name = nameof(ArJobCardHd.OriginalAmount), ResourceType = typeof(ArJobCardHd))]       
        public decimal? OriginalAmount { get; set; }

        [MaxLength(100)]
        [Display(Name = nameof(ArJobCardHd.CreditNote), ResourceType = typeof(ArJobCardHd))]
        public string CreditNote { get; set; }

        [Display(Name = nameof(ArJobCardHd.CustomerVatPercentage), ResourceType = typeof(ArJobCardHd))]
        public decimal? CustomerVatPercentage { get; set; }

        [Display(Name = nameof(ArJobCardHd.CustomerVatAmount), ResourceType = typeof(ArJobCardHd))]
        public decimal? CustomerVatAmount { get; set; }

        [Display(Name = nameof(ArJobCardHd.ExcessAmount), ResourceType = typeof(ArJobCardHd))]
        public decimal? ExcessAmount { get; set; }

        [Display(Name = nameof(ArJobCardHd.ExcessVatPercentage), ResourceType = typeof(ArJobCardHd))]
        public decimal? ExcessVatPercentage { get; set; }

        [Display(Name = nameof(ArJobCardHd.ExcessVatAmount), ResourceType = typeof(ArJobCardHd))]
        public decimal? ExcessVatAmount { get; set; }

        [Display(Name = nameof(ArJobCardHd.DiscountAmount), ResourceType = typeof(ArJobCardHd))]
        public decimal? DiscountAmount { get; set; }

        [Display(Name = nameof(ArJobCardHd.FndSalesMenId), ResourceType = typeof(ArJobCardHd))]
        public long? FndSalesMenId { get; set; }

        [Display(Name = nameof(ArJobCardHd.FndSalesMen), ResourceType = typeof(ArJobCardHd))]
        public FndSalesMenVM FndSalesMen { get; set; }

        #region LookupValues

        [Display(Name = nameof(ArJobCardHd.JobTypeLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long JobTypeLkpId { get; set; }
        public FndLookupValuesVM FndJobTypeLkp { get;  set; }


        [Display(Name = nameof(ArJobCardHd.PoliceReportSourceLkpId), ResourceType = typeof(ArJobCardHd))]       
        public long? PoliceReportSourceLkpId { get; set; }
        public FndLookupValuesVM FndPoliceReportSourceLkp { get; set; }


        [Display(Name = nameof(ArJobCardHd.VehicleEmirateLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long? VehicleEmirateLkpId { get; set; }
        public FndLookupValuesVM FndVehicleEmirateLkp { get;  set; }


        [Display(Name = nameof(ArJobCardHd.VehicleMakeLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VehicleMakeLkpId { get; set; }
        public FndLookupValuesVM FndVehicleMakeLkp { get;  set; }


        [Display(Name = nameof(ArJobCardHd.VehicleModelLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VehicleModelLkpId { get; set; }
        public FndLookupValuesVM FndVehicleModelLkp { get;  set; }


        [Display(Name = nameof(ArJobCardHd.VehicleColorLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long VehicleColorLkpId { get; set; }
        public FndLookupValuesVM FndVehicleColorLkp { get;  set; }


        [Display(Name = nameof(ArJobCardHd.ExcessStatusLkpId), ResourceType = typeof(ArJobCardHd))]
        public long? ExcessStatusLkpId { get; set; }
        public FndLookupValuesVM FndExcessStatusLkp { get;  set; }

        [Display(Name = nameof(ArJobCardHd.StatusLkpId), ResourceType = typeof(ArJobCardHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public long StatusLkpId { get; set; }
        public FndLookupValuesVM FndStatusLkp { get;  set; }

        #endregion

        public string AttachmentsListStr { get; set; }

        public ICollection<ArJobCardAttachmentsDto> ArJobCardAttachments => string.IsNullOrEmpty(AttachmentsListStr) ?
           new List<ArJobCardAttachmentsDto>() : Helper<List<ArJobCardAttachmentsDto>>.Convert(AttachmentsListStr);
    }
}