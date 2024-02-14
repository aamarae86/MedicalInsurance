using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApPdcInterface.ProcDto
{
    public  class GetItemStockDataOutput
    {
        public long Id { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
       
        public decimal ItemQtys { get; set; }
        public decimal WhQty { get; set; }
      
       


    }
}
