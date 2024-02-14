using Abp.AutoMapper;
using ERP._System.__HR._HRPaperRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
    [AutoMap(typeof(HrPaperRequest))]

   public class HrPaperRequestCreateDto
    {
        public string PaperReqNumber { get; set; }
        public string PaperReqDate { get; set; }
      
        public string ReqDetails { get; set; }

        public ICollection<HrPaperRequestAttachmentDto> HrPaperRequestAttachmentdetails { get; set; }

    }
}
