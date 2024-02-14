using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ApBankAccounts.Dto
{
    [AutoMapFrom(typeof(ApBankAccounts))]
    [AutoMapTo(typeof(ApBankAccounts))]
    [AutoMap(typeof(ApBankAccounts))]
    public class ApBankAccountsDto : EntityDto<long>
    {
        [Required]
        [MaxLength(100)]
        public string BankAccountNameAr { get; set; }
        [Required]
        [MaxLength(100)]
        public string BankAccountNameEn { get;  set; }
        public int CurrencyId { get;  set; }
        public decimal CurrencyRate { get;  set; }
        public long? AccountId { get;  set; }
        public long? cPdcAccountId { get;  set; }
        public long? PdcCollAccountId { get;  set; }
        public long? ApPdcCollAccountId { get;  set; }
        public long BankId { get;  set; }

        public bool IsActive { get; set; }
    }
}
