using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Castle.MicroKernel.SubSystems.Conversion;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    [AutoMap(typeof(FmContracts))]
    public class FmContractsDto : AuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(Id.ToString());
        public string ContractNumber { get; set; }
        public long StatusLkpId { get; set; }
        public string StatusLkpValue { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public long PaymentTypeLkpId { get; set; }
        public string PaymentTypeLkpValue { get; set; }
        public string ContractDate { get; set; }
        public long VendorId { get; set; }
        public string VendorValue { get; set; }
        public string Comments { get; set; }
        public long AccountId { get; set; }
        public string Accountvalue { get; set; }
        public decimal AnnualAmount { get; set; }
        public decimal RentAmount { get; set; }
        public string VendorContractNumber { get; set; }
        public long AdvAccountId { get; set; }
        public string AdvAccountValue { get; set; }



        public FndLookupValuesDto PaymentTypesValues { get; set; }
        public ApVendorsDto ApVendorsValues { get; set; }
        public GlCodeComDetailsDto AccounGlCodeComDetails { get; set; }
        public GlCodeComDetailsDto AdvGlCodeComDetails { get; set; }
         




        public ICollection<FmContractVisitsDto> FmContractVisits { get; set; }
        public ICollection<FmBuildingsContractsDto> FmBuildingsContracts { get; set; }
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }
                       
        public string codeComUtilityTexts_alt1 { get; set; }
                       
    }






}
