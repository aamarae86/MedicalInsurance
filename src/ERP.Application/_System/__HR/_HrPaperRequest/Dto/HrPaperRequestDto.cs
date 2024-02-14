using Abp.AutoMapper;
using ERP._System.__HR._HRPaperRequest;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System.__HR._PaperReqType.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
    [AutoMap(typeof(HrPaperRequest))]
    public  class HrPaperRequestDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string PaperReqNumber { get;  set; }
        public string PaperReqDate { get;  set; }
      
        public string ReqDetails { get;  set; }


        public ICollection<HrPaperRequestAttachmentDto> HrPaperRequestAttachmentdetails { get; set; }



    }
}
