using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP._System.__AidModule._Portal.UserIncomes;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    [AutoMap(typeof(ScPortalRequestIncome))]
    public class ScPortalRequestIncomeDto : EntityDto<long>, IDetailRowStatus
    {
        public string IncomeSourceName { get; set; }

        public decimal MonthlyIncomeAmount { get; set; }

        public long PortalRequestId { get; set; }

        public string rowStatus { get; set; }

    }
}
