using Abp.AutoMapper;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts.Dto
{
    [AutoMap(typeof(PmPropertiesRevenueAccounts))]
    public class PmPropertiesRevenueAccountsDto : CodeComUtility, IDetailRowStatus
    {
        public long id { get; set; }

        public long AccountId { get;  set; }

        public long AdvanceAccountId { get;  set; }

        public long PropertyId { get;  set; }

        public decimal Percentage { get;  set; }

        public string rowStatus { get ; set; }
    }
}
