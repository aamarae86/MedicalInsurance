using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
   public  class HrPaperRequestSearchDto
    {

        public string PaperReqNumber { get; set; }
       
        public override string ToString()
         => $"Params.PaperReqNumber={PaperReqNumber}";


    }
}
