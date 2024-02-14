using Abp.Application.Services.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    public class GlJeIntegrationLinesBaseDto : EntityDto<long>, IDetailRowStatus
    {
        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public long GlJeIntegrationHeaderId { get; set; }

        public long JeIntegrationLineTypeLkpId { get; set; }

        public long AccountId { get; set; }

        public string JeIntegrationLineNotes { get; set; }

        public string rowStatus { get; set; }

    }
}
