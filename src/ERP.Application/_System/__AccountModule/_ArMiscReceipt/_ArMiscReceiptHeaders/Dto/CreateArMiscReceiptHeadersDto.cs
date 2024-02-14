using Abp.AutoMapper;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    [AutoMap(typeof(ArMiscReceiptHeaders))]
    public class CreateArMiscReceiptHeadersDto
    {
        public string CheckNumber { get; set; }

        public string ReceiptNumber { get; set; }

        public string MiscReceiptDate { get; set; }

        public long? BankAccountId { get; set; }

        public long? ReceiptTypeLkpId { get; set; }

        public string Notes { get; set; }

        public long? PostedLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ArMiscReceiptHeadersPost);

        public long? TransactionTypeLkpId => 54;

        public long? CollectorId { get; set; }

        public decimal? Amount { get; set; }

        public string ManualReceiptNumber { get; set; }

        public long? BeneficentId { get; set; }

        public long? SourceCodeLkpId => Convert.ToInt64(FndEnum.FndLkps.ArMiscReceiptHeadersSourceCode);

        public long? SourceId { get; set; }

        public string Lang { get; set; }

        public List<ListArMiscReceiptDetailsVM> ListArMiscReceiptDetailsVM { get; set; }
        public List<ListArMiscReceiptLinesVM> ListArMiscReceiptLinesVM { get; set; }
    }
}
