using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PaperReqType.Dto
{
  public  class PaperReqTypeSearchDto
    {
        public string PaperReqTypeName { get; set; }
        public override string ToString()
         => $"Params.PaperReqTypeName={PaperReqTypeName}";

    }
}
