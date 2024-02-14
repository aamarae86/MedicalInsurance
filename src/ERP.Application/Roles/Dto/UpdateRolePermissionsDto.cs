using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Roles.Dto
{
    public class UpdateRolePermissionsDto : EntityDto
    {
        public List<string> GrantedPermissionNames { get; set; }
    }
}
