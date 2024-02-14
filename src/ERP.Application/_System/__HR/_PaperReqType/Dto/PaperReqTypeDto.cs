using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HRPaperRequest;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PaperReqType.Dto
{
    [AutoMap(typeof(PaperReqType))]
    public class PaperReqTypeDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string PaperReqTypeName { get; set; }
    
    }
}
