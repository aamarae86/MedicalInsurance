using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._Counters.ProcDto
{
    public class GetCounterInputDto: IMustHaveTenant
    {
        public string CounterName { get; set; }
        public string Lang { get; set; }
        public int year { get; set; }

        public int TenantId { get; set; }
    }
}
