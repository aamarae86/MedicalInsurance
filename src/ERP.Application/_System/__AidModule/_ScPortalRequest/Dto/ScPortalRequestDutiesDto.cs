using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System.__AidModule._Portal.UserDuites;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMap(typeof(ScPortalRequestDuties))]
    public class ScPortalRequestDutiesDto : EntityDto<long>, IDetailRowStatus
    {
        public string DutyType { get; set; }

        public string DutyDescription { get; set; }

        public decimal MonthlyAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public long PortalRequestId { get; set; }

        public string rowStatus { get; set; }

    }
}
