using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet.Dto
{
   public  class HrPersonTimeSheetSearchDto
    {
        public string TimeSheetNumber { get; set; }
        public long HrPersonId { get; set; }
        public string TimeSheetDate { get; set; }
        public long TimeSheetTypeId { get; set; }
        public override string ToString()
         => $"Params.HrPersonId={HrPersonId}&Params.TimeSheetDate={TimeSheetDate}&Params.TimeSheetNumber={TimeSheetNumber}&&Params.TimeSheetTypeId={TimeSheetTypeId}";

    }
}
