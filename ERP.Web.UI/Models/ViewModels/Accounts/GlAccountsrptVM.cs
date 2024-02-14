using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class GlAccountsrptVM
    {
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public int Level { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&TenantId={TenantId}&Level={Level}";
        }
    }
}