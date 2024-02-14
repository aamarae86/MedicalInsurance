using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._GlAccounts.Dto
{
    [AutoMapFrom(typeof(GlAccounts))]
    [AutoMapTo(typeof(GlAccounts))]
    [AutoMap(typeof(GlAccounts))]
    public class CreateGlAccountsDto
    {
        public string Code { get; set; }
        [Required]
        [MaxLength(4000)]
        public string DescriptionEn { get; set; }
        [Required]
        [MaxLength(4000)]
        public string DescriptionAr { get; set; }
        public bool TrialBalance { get; set; }
        public bool CashFlow { get; set; }
        public bool Expense { get; set; }
        public bool Revenue { get; set; }
        public bool Libility { get; set; }
        public bool Assets { get; set; }
        public bool ProfitLoss { get; set; }
        public bool BalanceSheet { get; set; }
        public bool Disabled { get; set; }
        public long? ParentId { get; set; }
        public string ParentPath { get; set; }
        public long NatureOfAccountLkpId { get;  set; }
        public FndLookupValuesDto FndLookupValues { get;  set; }
    }
}
