using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    [AutoMap(typeof(FmContracts))]
    public class FmContractsCreateDto : CodeComUtility //EntityDto<long>
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
    }
}
