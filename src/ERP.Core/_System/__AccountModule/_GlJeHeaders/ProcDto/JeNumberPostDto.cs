using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.ProcDto
{
    public class JeNumberPostDto:IMustHaveTenant
    {
        public DateTime TransDate { get; set; }
        public long PeriodId { get; set; }
        public int TenantId { get; set; }
    }
}
