using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonTimeSheet;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._TimeSheetType.Dto
{
    [AutoMap(typeof(TimeSheetType))]
    public  class TimeSheetTypeDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string TimeSheetTypeName { get; set; }
    }
}
