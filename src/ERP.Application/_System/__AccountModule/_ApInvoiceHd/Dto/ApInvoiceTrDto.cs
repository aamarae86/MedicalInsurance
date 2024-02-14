using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    [AutoMap(typeof(ApInvoiceTr))]
    public class ApInvoiceTrDto : EntityDto<long>, IDetailRowStatus, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string Desc { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal Total { get; set; }

        public long ApInvoiceHdId { get; set; }

        public long AccountId { get; set; }

        public long? TaxPercentageLkpId { get; set; }

        public string TaxPercentageNameAr { get; set; }

        public string TaxPercentageNameEn { get; set; }

        public string rowStatus { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
    }
}
