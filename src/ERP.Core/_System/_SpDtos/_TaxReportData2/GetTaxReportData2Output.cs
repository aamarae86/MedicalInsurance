﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._SpDtos._TaxReportData2
{
   public class GetTaxReportData2Output
    {
        public string SourceName { get; set; }
        public string PropertyName { get; set; }
        public string CityName { get; set; }
        public string TaxNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime TransDate { get; set; }
        public string TransNo { get; set; }
        public decimal AmountBeforTax { get; set; }
        public decimal TaxVal { get; set; }
        public decimal TotalVal { get; set; }

 
    }
}