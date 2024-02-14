using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System;

namespace ERP._System.__ReportsPms.Input
{
    public class rptArDebitCreditInput
    {
        public long? CustomerId { get; set; }
        public int? TenantId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Lang { get; set; }
        public bool IsNotSettled { get; set; }
    }

    public class rptArDebitCreditInputHelper
    {
        public long? CustomerId { get; set; }
        public int? TenantId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Lang { get; set; }
        public bool IsNotSettled { get; set; }
        public override string ToString() => $"?Lang={Lang}&CustomerId={CustomerId}&FromDate={FromDate}&ToDate={ToDate}&IsNotSettled={IsNotSettled}";
    }

    public class rptArDebitCreditInputPaged:PagedAndSortedResultRequestDto
    {
      public  rptArDebitCreditInputHelper Params { get; set; }
        public SortModel OrderByValue { get; set; }

    }
 }
