using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP.Users.Dto;

namespace ERP._System._ApUserBankAccess.Dto
{
    [AutoMap(typeof(ApUserBankAccess))]
    public class ApUserBankAccessEditDto : EntityDto<long>
    {
        public long? BankAccountId { get; set; }

        public bool IsPrimaryCash { get; set; }

        public long UserId { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public UserDto User { get; set; }
    }
}
