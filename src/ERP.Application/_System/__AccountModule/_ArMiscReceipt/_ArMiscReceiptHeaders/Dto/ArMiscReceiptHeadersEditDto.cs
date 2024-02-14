using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArMiscReceiptHeaders;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    [AutoMap(typeof(ArMiscReceiptHeaders))]
    public class ArMiscReceiptHeadersEditDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string MiscReceiptDate { get; set; }

        public long? BankAccountId { get; set; }

        public long? ReceiptTypeLkpId { get; set; }

        public long? CollectorId { get; set; }

        public decimal? Amount { get; set; }

        public string ManualReceiptNumber { get; set; }

        public long? BeneficentId { get; set; }

        public string Notes { get; set; }

        public List<ListArMiscReceiptDetailsVM> ListArMiscReceiptDetailsVM { get; set; }

        public List<ListArMiscReceiptLinesVM> ListArMiscReceiptLinesVM { get; set; }
    }
}
