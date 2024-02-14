using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class GetrptArJobSurveyInputReportVM
    {
        public long? Id { get; set; }
        public int TenantId { get; set; }
        public string Lang { get; set; }

        public override string ToString() => $"?Id={Id}" + $"&TenantId={TenantId}" + $"&Lang={Lang}";
    }
}