using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ItemMovementsReport.Dto
{
    public class ItemMovementDto
    {
        public string Id { get; set; }
        public string  Date { get; set; }
        public decimal QtyIn { get; set; }   
        public decimal QtyOut { get; set; }
        public decimal Balance { get; set; }
        public string TranType { get; set; }
        public string InvNo { get; set; }
        public string Customer { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
