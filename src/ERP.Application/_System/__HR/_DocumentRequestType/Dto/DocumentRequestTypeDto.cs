using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonRequestDocument;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._DocumentRequestType.Dto
{
    [AutoMap(typeof(DocumentRequestType))]
    public class DocumentRequestTypeDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string DocumentRequestName { get; set; }



    }
}
