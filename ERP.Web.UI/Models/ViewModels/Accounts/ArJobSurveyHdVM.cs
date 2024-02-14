using ERP._System.__AccountModule._ArJobSurveyTr;
using ERP._System._ArInvoiceTr.Dto;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Accounts;
using ERP.ResourcePack.Common;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class ArJobSurveyHdVM : BasePostAuditedVM<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
         
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ClaimNo), ResourceType = typeof(ArJobSurveyHd))]
        public string ClaimNo { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ClaimDate), ResourceType = typeof(ArJobSurveyHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string ClaimDate { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.InsuredVehicle), ResourceType = typeof(ArJobSurveyHd))]
        public bool InsuredVehicle { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.InsuredVehicle), ResourceType = typeof(ArJobSurveyHd))]
        public bool InsuredVehicleAlt { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.TPVehicle), ResourceType = typeof(ArJobSurveyHd))]
        public bool TPVehicle { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.TPVehicle), ResourceType = typeof(ArJobSurveyHd))]
        public bool TPVehicleAlt { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.PlateNo), ResourceType = typeof(ArJobSurveyHd))]
        [Required(ErrorMessageResourceType = typeof(Settings), ErrorMessageResourceName = nameof(Settings.Required))]
        public string PlateNo { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.VehicleMakeLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? VehicleMakeLkpId { get; set; }
        public FndLookupValuesVM ArJobCardVehicleMakeLkp { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.VehicleModelLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? VehicleModelLkpId { get; set; }
        public FndLookupValuesVM ArJobCardVehicleModelLkp { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ArJobSurveyStatusLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? ArJobSurveyStatusLkpId { get; set; }
        public FndLookupValuesVM ArJobSurveyStatusLkp { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ContactName), ResourceType = typeof(ArJobSurveyHd))]

        public string ContactName { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ContactNo), ResourceType = typeof(ArJobSurveyHd))]
        public string ContactNo { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.Attribute1), ResourceType = typeof(ArJobSurveyHd))]
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.EstimatedAmount), ResourceType = typeof(ArJobSurveyHd))]
        public decimal? EstimatedAmount { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.LabourCharges), ResourceType = typeof(ArJobSurveyHd))]
        public decimal? LabourCharges { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.LumpsumAmount), ResourceType = typeof(ArJobSurveyHd))]
        public decimal? LumpsumAmount { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.TotalAmount), ResourceType = typeof(ArJobSurveyHd))]
        public string TotalAmount => ((this.EstimatedAmount==null?0: this.EstimatedAmount) + (this.LabourCharges==null?0: this.LabourCharges) + (this.LumpsumAmount==null?0: this.LumpsumAmount)).ToString();
       
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.VehicleColorLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? VehicleColorLkpId { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.VehicleEmirateLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? VehicleEmirateLkpId { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.JobTypeLkpId), ResourceType = typeof(ArJobSurveyHd))]
        public long? JobTypeLkpId { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.ArCustomerId), ResourceType = typeof(ArJobSurveyHd))]
        public long? ArCustomerId { get; set; }
        public ArCustomersVM ArCustomers { get; set; }
        public FndLookupValuesVM JobTypeLkp { get; set; }
        public FndLookupValuesVM VehicleColorLkp { get; set; }
        public FndLookupValuesVM VehicleEmirateLkp { get; set; }
        [Display(Name = nameof(ERP.ResourcePack.Accounts.ArJobSurveyHd.Comments), ResourceType = typeof(ArJobSurveyHd))]
        public string Comments { get; set; }
        public string ListArJobSurveyTr { get; set; }
        public List<ArJobSurveyTrDto> ArJobSurveyTr => string.IsNullOrEmpty(ListArJobSurveyTr) ? new List<ArJobSurveyTrDto>() :
            Helper<List<ArJobSurveyTrDto>>.Convert(ListArJobSurveyTr);
    }
}