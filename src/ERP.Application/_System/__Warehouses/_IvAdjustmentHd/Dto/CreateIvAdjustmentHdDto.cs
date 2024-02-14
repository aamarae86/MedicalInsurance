using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    [AutoMap(typeof(IvAdjustmentHd))]
    public class CreateIvAdjustmentHdDto
    {
        [MaxLength(30)]
        public string AdjustmentNumber { get; set; }

        public string AdjustmentDate { get; set; }

        public long? StatusLkpId => 767;

        public long? AdjustmentTypeLkpId { get; set; }

        public long? IvWarehouseId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<IvAdjustmentTrDto> AdjustmentTr { get; set; }
    }
}
