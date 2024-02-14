using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Output
{
    public class rptPmPropertiesIncomeOutput
    {
        public long OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerNumber { get; set; }
        public long PropertyId { get; set; }
        public string PropertyName { get; set; }
        //public decimal ObAdvIncome { get; set; }
        //public decimal ObCurIncome { get; set; }
        public DateTime ContractDate { get; set; }
        public string UnitNo { get; set; }
        public string ContractNumber { get; set; }
        public decimal RentAmount { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string TenantName { get; set; }
        //public string JeNumber { get; set; }
        public decimal CurIncome { get; set; }
        public decimal AdvIncome { get; set; }
        public decimal OtherIncome { get; set; }
    }
}
