using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._TimeSheetType.Dto
{
   public  class TimeSheetTypeSearchDto
    {
        public string TimeSheetTypeName { get; set; }
        public override string ToString()
         => $"Params.TimeSheetTypeName={TimeSheetTypeName}";
    }
}
