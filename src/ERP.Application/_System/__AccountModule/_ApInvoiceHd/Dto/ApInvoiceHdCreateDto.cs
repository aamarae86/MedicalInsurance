using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    [AutoMap(typeof(ApInvoiceHd))]
    public class ApInvoiceHdCreateDto : CodeComUtility
    {
        public string HdInvNo { get; set; }

        public string HdDate { get; set; }

        public decimal CurrencyRate { get; set; }

        public decimal? PrepaidAmount { get; set; }

        public string Comments { get; set; }

        public int? PrepaidPeriod { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ApInvoiceHdStatues);

        public long HdTypeLkpId { get; set; }

        public long VendorId { get; set; }

        public int CurrencyId { get; set; }

        public long? FromAccountId { get; set; }

        public long? ToAccountId { get; set; }

        public ICollection<ApInvoiceTrDto> InvoiceDetails { get; set; }
    }
}
