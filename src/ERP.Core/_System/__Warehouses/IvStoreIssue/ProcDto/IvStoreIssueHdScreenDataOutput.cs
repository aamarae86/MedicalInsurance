using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses.IvStoreIssue.ProcDto
{
    public class IvStoreIssueHdScreenDataOutput
    {
        public string StoreIssueNumber { get; set; }
        public DateTime StoreIssueDate { get; set; }
        public string ManualNo { get; set; }
        public string BeneficiaryName { get; set; }
        public string Comment { get; set; }
        public string statu { get; set; }
        public string IssueType { get; set; }
        public string BeneficiaryType { get; set; }
        public string WarehouseName { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public decimal Qty { get; set; }
        public decimal AvgCost { get; set; }
        public decimal Total { get; set; }
    }
}
