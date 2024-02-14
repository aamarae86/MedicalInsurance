using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;

namespace ERP._System._ApBanks.Dto
{
    [AutoMap(typeof(ApBanks))]
    public class ApBanksDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string BankNameAr { get; set; }

        public string BankNameEn { get; set; }

        public long BankTypeLkpId { get; set; }

        public bool IsActive { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public List<ListApBankAccounts> ListApBankAccountsDetails { get; set; }

    }
}
