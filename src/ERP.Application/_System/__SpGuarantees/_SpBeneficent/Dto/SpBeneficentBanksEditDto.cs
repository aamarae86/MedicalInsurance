using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    [AutoMap(typeof(SpBeneficentBanks))]
    public class SpBeneficentBankEditDto : EntityDto<long>,  IDetailRowStatus//,IMustHaveTenant
    {
        //public int TenantId { get; set; }

        /*[{"index":1,
         * "bank_LkpId":"34",
         * "bankNameAr":"بنك نور الاسلامي",
         * "bankNameEn":"بنك نور الاسلامي",
         * "accountNumber":"4324",
         * "accountOwnerName":"dfsfsd",
         * "isDefault":"true",
         * "rowStatus":"New",
         * "id":0}]*/

        public long BeneficentId { get; set; }

        public long BankLkpId { get; set; }

        public string AccountNumber { get; set; }

        public string AccountOwnerName { get; set; }

        public bool IsDefault { get; set; }

        public string rowStatus { get; set; }
    }
}
