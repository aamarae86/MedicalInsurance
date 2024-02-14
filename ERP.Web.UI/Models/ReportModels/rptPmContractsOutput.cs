using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptPmContractsOutput
    {
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public string PmTenantName { get; set; }
        public string PropertyName { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitNo { get; set; }
        public decimal RentAmount { get; set; }
        public string StatusName { get; set; }
        public string ActivityName { get; set; }
    }
}