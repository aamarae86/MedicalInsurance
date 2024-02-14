using Abp.AutoMapper;
using ERP._System.__HR._HrPersonPermission;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPermissionType
{
    [AutoMap(typeof(HrPermissionType))]
    public class HrPermissionTypeCreateDto
    {
        public string PermissionName { get; set; }
    }
}
