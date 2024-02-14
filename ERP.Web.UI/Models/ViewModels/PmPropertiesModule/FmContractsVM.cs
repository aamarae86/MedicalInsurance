using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP.ResourcePack.PmPropertiesModule;
using System.ComponentModel.DataAnnotations;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP.Front.Helpers.Core;
using ERP._System._FndLookupValues.Dto;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP._System.__PmPropertiesModule._PmProperties.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP.Helpers.Parameters;

namespace ERP.Web.UI.Models.ViewModels.PmPropertiesModule
{
    public class FmContractsVM : BasePostAuditedVM<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {

        public string EncId { get; set; }

        [Display(Name = nameof(FmContracts.ContractNumber), ResourceType = typeof(FmContracts))]
        public string ContractNumber { get; set; }

        [Display(Name = nameof(FmContracts.StatusLkpId), ResourceType = typeof(FmContracts))]
        public long StatusLkpId { get; set; }

        [Display(Name = nameof(FmContracts.StatusLkpValue), ResourceType = typeof(FmContracts))]
        public string StatusLkpValue { get; set; }


        [Display(Name = nameof(FmContracts.StartDate), ResourceType = typeof(FmContracts))]
        public string StartDate { get; set; }


        [Display(Name = nameof(FmContracts.EndDate), ResourceType = typeof(FmContracts))]
        public string EndDate { get; set; }

        [Display(Name = nameof(FmContracts.PaymentTypeLkpId), ResourceType = typeof(FmContracts))]
        public long PaymentTypeLkpId { get; set; }


        [Display(Name = nameof(FmContracts.PaymentTypeLkpValue), ResourceType = typeof(FmContracts))]
        public string PaymentTypeLkpValue { get; set; }


        [Display(Name = nameof(FmContracts.ContractDate), ResourceType = typeof(FmContracts))]
        public string ContractDate { get; set; }


        [Display(Name = nameof(FmContracts.VendorId), ResourceType = typeof(FmContracts))]
        public long? VendorId { get; set; }

        [Display(Name = nameof(FmContracts.VendorValue), ResourceType = typeof(FmContracts))]
        public string VendorValue { get; set; }

        [Display(Name = nameof(FmContracts.Comments), ResourceType = typeof(FmContracts))]
        public string Comments { get; set; }

        [Display(Name = nameof(FmContracts.AccountId), ResourceType = typeof(FmContracts))]
        public long? AccountId { get; set; }

        [Display(Name = nameof(FmContracts.Accountvalue), ResourceType = typeof(FmContracts))]
        public string Accountvalue { get; set; }

        [Display(Name = nameof(FmContracts.AnnualAmount), ResourceType = typeof(FmContracts))]
        public decimal AnnualAmount { get; set; }

        [Display(Name = nameof(FmContracts.RentAmount), ResourceType = typeof(FmContracts))]
        public decimal? RentAmount { get; set; }


        [Display(Name = nameof(FmContracts.VendorContractNumber), ResourceType = typeof(FmContracts))]
        public string VendorContractNumber { get; set; }


        [Display(Name = nameof(FmContracts.AdvAccountId), ResourceType = typeof(FmContracts))]
        public long? AdvAccountId { get; set; }

        [Display(Name = nameof(FmContracts.AdvAccountValue), ResourceType = typeof(FmContracts))]
        public string AdvAccountValue { get; set; }


        public string ListFmContractVisitsStr { get; set; }
        public string ListFmBuildingsContractsStr { get; set; }

        //public ICollection<FmContractVisitsDto> FmContractVisits { get; set; }
        //public ICollection<FmBuildingsContractsDto> FmBuildingsContracts { get; set; }


     
       

        public virtual ICollection<FmContractVisitsDto> FmContractVisitsList =>
            string.IsNullOrEmpty(ListFmContractVisitsStr) ?
            new List<FmContractVisitsDto>() :
            Helper<List<FmContractVisitsDto>>.Convert(ListFmContractVisitsStr);

        public virtual ICollection<FmBuildingsContractsDto> FmBuildingsContractsList =>
            string.IsNullOrEmpty(ListFmBuildingsContractsStr) ?
            new List<FmBuildingsContractsDto>() :
            Helper<List<FmBuildingsContractsDto>>.Convert(ListFmBuildingsContractsStr);


        //public FndLookupValuesDto PaymentTypesValues { get; set; }
        //public ApVendorsDto ApVendorsValues { get; set; }
        //public GlCodeComDetailsDto AccounGlCodeComDetails { get; set; }
        //public GlCodeComDetailsDto AdvGlCodeComDetails { get; set; }

        #region FmBuildingsContracts
        [Display(Name = nameof(FmContracts.ContractNumber), ResourceType = typeof(FmContracts))]
        public long ContractId { get; set; }
        [Display(Name = nameof(FmContracts.Amount), ResourceType = typeof(FmContracts))]
        public decimal Amount { get; set; }
        [Display(Name = nameof(FmContracts.PmPropertiesId), ResourceType = typeof(FmContracts))]
        public long PmPropertiesId { get; set; }
        public string PmPropertiesValue { get; set; }
        public string rowStatus { get; set; }
        #endregion



        #region FmContractVisits
        [Display(Name = nameof(FmContracts.VisitNumber), ResourceType = typeof(FmContracts))]
        public string VisitNumber { get; set; }
        [Display(Name = nameof(FmContracts.VisitDate), ResourceType = typeof(FmContracts))]
        public DateTime VisitDate { get; set; }
        [Display(Name = nameof(FmContracts.EngineerId), ResourceType = typeof(FmContracts))]
        public long EngineerId { get; set; }

        #endregion


        public string codeComUtilityTexts { get; set; }
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }



        //public FmContractsDto FmContract { get; set; }

        //public PmPropertiesDto PmProperties { get; set; }

        //public FmEngineersDto FmEngineers { get; set; }






    }
}