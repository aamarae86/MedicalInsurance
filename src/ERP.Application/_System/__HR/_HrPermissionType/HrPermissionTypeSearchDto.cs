using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPermissionType
{
   public  class HrPermissionTypeSearchDto
    {
        public string PermissionName { get; set; }
        public override string ToString()
         => $"Params.PermissionName={PermissionName}";
    }
}
