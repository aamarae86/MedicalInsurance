namespace ERP.Web.UI.Models.ReportModels
{
    public class PyPayrollDetailsOutput
    {
        public string EmployeeFullName { get; set; }

        public string EmployeeNumber { get; set; }

        public string JobDisc { get; set; }

        public decimal BasicSalary { get; set; }

        public decimal TransportationAllowance { get; set; }

        public decimal OtherAllowances { get; set; }

        public decimal CommunicationAllowance { get; set; }

        public decimal NetSalary { get; set; }

        public decimal Addition { get; set; }

        public decimal Deduction { get; set; }

        public decimal CostOfLivingAllowance { get; set; }

        public decimal HousingAllowance { get; set; }

        public decimal TotalPaid { get; set; }

        public string OperationNumber { get; set; }

        public string PeriodNameAr { get; set; }

        public string PyPayrollTypeName { get; set; }
    }
}