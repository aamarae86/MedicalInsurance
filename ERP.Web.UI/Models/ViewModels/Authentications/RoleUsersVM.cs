using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Authentications
{
    public class RoleUsersVM
    {
        public int RoleId { get; set; }

        public List<UserInRoleVM> UsersInRole { get; set; }
        public List<int> UserIds { get; set; }
    }
}