using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._FmContracts;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    [AutoMap(typeof(FmContracts))]
    public class FmContractsEditDto : EntityDto<long>, ICodeComUtilityIds  // EntityDto<long>
    {
        public string ContractNumber { get; set; }
        public long StatusLkpId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public long PaymentTypeLkpId { get; set; }
        public string ContractDate { get; set; }
        public long VendorId { get; set; }
        public string Comments { get; set; }
        public long AccountId { get; set; }
        public decimal AnnualAmount { get; set; }
        public decimal RentAmount { get; set; }
        public string VendorContractNumber { get; set; }
        public long AdvAccountId { get; set; }
     
        public ICollection<FmContractVisitsDto> FmContractVisitsList { get; set; }
        public ICollection<FmBuildingsContractsDto> FmBuildingsContractsList { get; set; }


        public string codeComUtilityIds { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }

        public string codeComUtilityTexts_alt1 { get; set; }

    }





}
