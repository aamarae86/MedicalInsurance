using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Parameters.Roles
{
    public class RolesParms
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }

        public string Description { get; set; }

        public List<string> GrantedPermissions { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public override string ToString()
        {
            return $"Params.Name={Name}&Params.DisplayName={DisplayName}&Params.NormalizedName={NormalizedName}&Params.Description={Description}&Params.IsStatic={IsStatic}&Params.IsDefault={IsDefault}";
        }
    }
}
