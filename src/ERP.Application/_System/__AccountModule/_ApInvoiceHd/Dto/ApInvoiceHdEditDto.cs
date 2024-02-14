using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using ERP.ModificationsValidation;
using System;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    [AutoMap(typeof(ApInvoiceHd))]
    public class ApInvoiceHdEditDto : CodeComUtility, IEntityDto<long>, IHasModificationTimeValidation
    {
        public long Id { get; set; }

        public string HdDate { get; set; }

        public decimal CurrencyRate { get; set; }

        public decimal? PrepaidAmount { get; set; }

        public string Comments { get; set; }

        public int? PrepaidPeriod { get; set; }

        public long HdTypeLkpId { get; set; }

        public long VendorId { get; set; }

        public int CurrencyId { get; set; }

        public long? FromAccountId { get; set; }

        public long? ToAccountId { get; set; }

        public ICollection<ApInvoiceTrDto> InvoiceDetails { get; set; }

        public DateTime? LastModificationTime { get; }
        public string LastModificationTimeStr { get; set; }
    }
}
