using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{
   public  class HrPersonRequestDocumentSearchDto
    {
        public string RequestNumber { get; set; }
        public long HrPersonId { get; set; }
        public string DocRequestDate { get; set; }
        public override string ToString()
         => $"Params.HrPersonId={HrPersonId}&Params.RequestNumber={RequestNumber}&Params.DocRequestDate={DocRequestDate}";

    }
}
