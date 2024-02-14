using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemMovementsReport.Dto
{
    public class ItemMovementSearchDto
    {
        public string FromDate { get; set; }   
        public string ToDate { get; set; }
        public long? IvItemId { get; set; }
        public long? IvWarehouseId { get; set; }
    }
}
