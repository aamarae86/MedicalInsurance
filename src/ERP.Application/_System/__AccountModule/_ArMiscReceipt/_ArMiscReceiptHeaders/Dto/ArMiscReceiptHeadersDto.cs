using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndCollectors.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    [AutoMap(typeof(ArMiscReceiptHeaders))]
    public class ArMiscReceiptHeadersDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string ReceiptNumber { get; set; }

        public string MiscReceiptDate { get; set; }

        public long? BankAccountId { get; set; }

        public long? ReceiptTypeLkpId { get; set; }

        public string Notes { get; set; }

        public long? PostedLkpId { get; set; }

        public long? TransactionTypeLkpId { get; set; }

        public long? CollectorId { get; set; }

        public decimal? Amount { get; set; }

        public string ManualReceiptNumber { get; set; }

        public long? BeneficentId { get; set; }

        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public SpBeneficentDto SpBeneficent { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public FndLookupValuesDto FndLookupValuesPostedLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesTransactionTypeLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesSourceCodeLkp { get; set; }

        public FndLookupValuesDto FndReceiptTypeLkp { get; set; }

        public FndCollectorsDto FndCollectors { get; set; }


        public List<ListArMiscReceiptDetailsVM> ListArMiscReceiptDetailsVM { get; set; }
        public List<ListArMiscReceiptLinesVM> ListArMiscReceiptLinesVM { get; set; }

    }
}
