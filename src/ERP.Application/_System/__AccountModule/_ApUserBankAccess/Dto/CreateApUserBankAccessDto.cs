using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApUserBankAccess.Dto
{
    [AutoMapFrom(typeof(ApUserBankAccess))]
    [AutoMapTo(typeof(ApUserBankAccess))]
    [AutoMap(typeof(ApUserBankAccess))]
    public class CreateApUserBankAccessDto
    {
        public long? BankAccountId { get;  set; }
        public bool IsPrimaryCash { get;  set; }
        public long UserId { get;  set; }
        public ApBankAccountsDto ApBankAccounts { get;  set; }
        public UserDto User { get;  set; }
    }
}
