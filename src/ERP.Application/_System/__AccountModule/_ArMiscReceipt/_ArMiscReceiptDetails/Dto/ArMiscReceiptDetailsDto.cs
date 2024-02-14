using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._FndLookupValues.Dto;
using System;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptDetails.Dto
{
    [AutoMap(typeof(ArMiscReceiptDetails))]
    public class ArMiscReceiptDetailsDto : EntityDto<long>
    {
        public long? MiscReceiptId { get; set; }

        public string CheckNumber { get; set; }

        public DateTime? MaturityDate { get; set; }

        public long? BankLkpId { get; set; }

        public decimal? Amount { get; set; }

        public long? BankAccountId { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

    }
}
