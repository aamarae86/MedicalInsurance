using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobSurveyHd.Proc
{
    public class GetrptArJobSurveyInput
    {
        public long? Id { get; set; }
        public int TenantId { get; set; }
        public string Lang { get; set; }

        public override string ToString() => $"?Id={Id}" + $"&TenantId={TenantId}" + $"&Lang={Lang}";
    }
}
