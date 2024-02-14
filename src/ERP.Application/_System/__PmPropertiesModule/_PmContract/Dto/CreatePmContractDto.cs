using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmContractAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails.Dto;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments.Dto;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._PmContract.Dto
{
    [AutoMap(typeof(PmContract))]
    public class CreatePmContractDto
    {
        public string ContractNumber { get; set; }

        public string ContractDate { get; set; }

        public string ContractStartDate { get; set; }

        public string ContractEndDate { get; set; }

        public string ContractEndDatePrint { get; set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string TaxNo { get; set; }

        public decimal TaxPercent { get; set; }

        public decimal RentAmount { get; set; }

        public decimal AnnualRentAmount { get; set; }

        public decimal? InsuranceAmount { get; set; }

        public long PmUnitTypeLkpId { get; set; }

        public long PropertyId { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_PmContractPost);

        public long PmTenantId { get; set; }

        public long PmPaymentNoLkpId { get; set; }

        public long PmActivityLkpId { get; set; }

        public long? ParentContractId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [MaxLength(4000)]
        public string Condition1 { get; set; }

        [MaxLength(4000)]
        public string Condition2 { get; set; }

        [MaxLength(4000)]
        public string Condition3 { get; set; }

        [MaxLength(4000)]
        public string Condition4 { get; set; }

        [MaxLength(4000)]
        public string Condition5 { get; set; }

        public ICollection<PmContractPaymentsDto> PmContPayments { get; set; }
        public ICollection<PmContractUnitDetailsDto> PmContUnitDetails { get; set; }
        public ICollection<PmOtherContractPaymentsDto> PmOtherContPayments { get; set; }
        public ICollection<PmContractAttachmentsDto> PmContAttachments { get; set; }
    }
}
