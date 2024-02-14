using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Output
{
    public class PmContractNotRenewedOutput
    {
        public string ContractNumber { get; set; }
        public string PmTenantName { get; set; }
        public string PropertyName { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitNo { get; set; }
        public decimal RentAmount { get; set; }
    }
}
