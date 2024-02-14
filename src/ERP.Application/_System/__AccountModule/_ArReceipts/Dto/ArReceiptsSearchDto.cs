using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    public class ArReceiptsSearchDto : EntityDto<long>
    {
        public string ReceiptNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public long? ArCustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public string ReceiptDateFrom { get; set; }
        public string ReceiptDateTo { get; set; }

        public override string ToString()
        {
            return $"Params.ReceiptNumber={ReceiptNumber}&Params.ArCustomerId={ArCustomerId}&Params.StatusLkpId={StatusLkpId}&Params.CurrencyId={CurrencyId}&Params.ReceiptDateFrom={ReceiptDateFrom}&Params.ReceiptDateTo={ReceiptDateTo}";
        }
    }

}
