using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobSurveyHd.Proc
{
    public class GetrptArJobSurveyPostInput : EntityDto<long>
    {
        //public long UserId { get; set; }

        public string Lang { get; set; }
        public int TenantId { get; set; }

    }
}
