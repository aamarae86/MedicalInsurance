using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonPermission;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPermissionType
{
    [AutoMap(typeof(HrPermissionType))]
    public class HrPermissionTypeDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string PermissionName { get; set; }
    }
}
