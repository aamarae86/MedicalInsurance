using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Helpers.Core
{
    public class Select2PagedResult
    {
        public long Total { get; set; }

        public List<Select2OptionModel> Results { get; set; }
    }

    public class PermissionsResult
    {
        public List<string> Permissions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var permission in Permissions)
            {
                sb.Append($"{permission},");
            }
            return sb.ToString();
        }
    }
}
