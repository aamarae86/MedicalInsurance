using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArMiscReceiptLines;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptLines.Dto
{
    [AutoMap(typeof(ArMiscReceiptLines))]
    public class ArMiscReceiptLinesDto : EntityDto<long>
    {
        public long? MiscReceiptId { get; set; }
        public decimal? MiscReceiptAmount { get; set; }
        public decimal? AdministrativePercent { get; set; }
        public string Notes { get; set; }
        public long? ReceiptTypeLkpId { get; set; }
        public long? CaseId { get; set; }
        public long? AccountId { get; set; }
        public string ManualReceiptNumber { get; set; }
        public long? SourceCodeLkpId { get; set; }
        public long? SourceId { get; set; }
        public long? AdminAccountID { get; set; }
        public long? SpContractDetailsId { get; set; }

    }
}
