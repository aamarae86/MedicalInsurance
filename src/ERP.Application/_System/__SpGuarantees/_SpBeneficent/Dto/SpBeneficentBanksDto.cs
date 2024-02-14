using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using AutoMapper;
//using ERP._System.__SpGuarantees._ScPortalRequestStudy.Dto;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    [AutoMapFrom(typeof(SpBeneficentBanks))]
    public class SpBeneficentBanksDto : EntityDto<long>//, IMustHaveTenant
    {
        //public int TenantId { get; set; }

        public long BeneficentId { get; set; }
        //public SpBeneficentDto Beneficent { get; set; }

        public long BankLkpId { get; set; }

        public string BankNameAr { get; set; }
        public string BankNameEn { get; set; }

        public string AccountNumber { get; set; }

        public string AccountOwnerName { get; set; }

        public bool IsDefault { get; set; }
    }
}
