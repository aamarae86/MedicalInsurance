using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Roles.Dto
{
    public class RoleUsersInsertDto
    {
        public int RoleId { get; set; }

        public List<int> UserIds { get; set; }
        public List<UserInRoleDto> UsersInRole { get; set; }
    }
}
