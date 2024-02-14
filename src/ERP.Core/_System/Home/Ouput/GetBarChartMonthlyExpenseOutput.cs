using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Home.Ouput
{
   public class GetBarChartMonthlyExpenseOutput
    {
        public string PeriodName { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
    }
}
