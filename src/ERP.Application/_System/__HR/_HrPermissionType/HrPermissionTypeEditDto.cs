using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__HR._HrPersonPermission;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPermissionType
{
    [AutoMap(typeof(HrPermissionType))]
    public class HrPermissionTypeEditDto : EntityDto<long>
    {
        public string PermissionName { get; set; }
    }
}
