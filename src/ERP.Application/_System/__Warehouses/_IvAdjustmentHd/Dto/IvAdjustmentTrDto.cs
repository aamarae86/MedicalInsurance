using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    [AutoMap(typeof(IvAdjustmentTr))]
    public class IvAdjustmentTrDto : EntityDto<long>
    {
        public long? IvAdjustmentHdId { get;  set; }
        public long? IvItemId { get;  set; }
        public string IvItemName { get;  set; }
        public string IvItemNumber { get; set; }
        public decimal? CurrentQty { get;  set; }
        public decimal? Qty { get;  set; }
        public string rowStatus { get; set; }
    }
}
