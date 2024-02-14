using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApBanks;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApBanks.Dto
{
    [AutoMap(typeof(ApBanks))]
    public class ApBanksEditDto : EntityDto<long>
    {
        public string BankNameAr { get; set; }

        public string BankNameEn { get; set; }

        public long BankTypeLkpId { get; set; }

        public bool IsActive { get; set; }

        public List<ListApBankAccounts> ListApBankAccountsDetails { get; set; }
    }
}
