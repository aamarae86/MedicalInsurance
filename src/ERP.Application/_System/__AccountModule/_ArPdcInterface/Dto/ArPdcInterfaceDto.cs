using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ArPdcInterface.Dto
{
    [AutoMapFrom(typeof(ArPdcInterface))]
    public class ArPdcInterfaceDto : PostAuditedEntityDto<long>
    {
        public long? SourceCodeLkpId { get; set; }
        public long? SourceId { get; set; }
        [MaxLength(30)]
        public string SourceNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public decimal? Amount { get; set; }
        [MaxLength(30)]
        public string CheckNumber { get; set; }
        public string MaturityDate { get; set; }
        public long? BankAccountId { get; set; }
        [MaxLength(4000)]
        public string Notes { get; set; }
        public string ConfirmedDate { get; set; }
        public string ReversedDate { get; set; }
        public long? CustomerId { get; set; }
        public long? BankLkpId { get; set; }
        public FndLookupValuesDto FndLookupValuesSourceCodeLkp { get; set; }
        public FndLookupValuesDto FndLookupValuesStatusLkp { get; set; }
        public FndLookupValuesDto FndLookupValuesBankLkp { get; set; }
        public ApBankAccountsDto ApBankAccounts { get; set; }
        public ArCustomersDto ArCustomers { get; set; }
        public ApBankAccountsDto DepositApBankAccounts { get; set; }
        public long? DepositBankAccountId { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
