using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GlAccounts.ProcDto
{
    public class GlAccountsScreenDataInput
    {
        public int TenantId { get; set; }
        public string Lang { get; set; }
    }
    public class GlAccountsScreenDataInputDto
    {
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&TenantId={TenantId}";
        }
    }
}
