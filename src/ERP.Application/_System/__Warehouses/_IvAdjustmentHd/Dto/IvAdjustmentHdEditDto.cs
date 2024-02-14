using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    [AutoMap(typeof(IvAdjustmentHd))]
    public class IvAdjustmentHdEditDto : EntityDto<long>
    {
        public string AdjustmentDate { get; set; }

        public long? AdjustmentTypeLkpId { get; set; }

        public long? IvWarehouseId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<IvAdjustmentTrDto> AdjustmentTr { get; set; }
    }
}
