using Abp.Application.Services.Dto;
using System;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssueDetailsBaseDto : EntityDto<long>
    {
        public long IvStoreIssueHdId { get; set; }

        public long IvItemId { get; set; }

        public long IvUnitId { get; set; }

        public decimal Qty { get; set; }

        public decimal AvgCost { get; set; }
    }
}
