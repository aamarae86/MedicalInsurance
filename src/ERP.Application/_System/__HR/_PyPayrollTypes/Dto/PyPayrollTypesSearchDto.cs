namespace ERP._System.__HR._PyPayrollTypes.Dto
{
    public class PyPayrollTypesSearchDto
    {
        public string PayrollTypeNumber { get; set; }

        public string PyPayrollTypeName { get; set; }

        public override string ToString()
              => $"Params.PayrollTypeNumber={PayrollTypeNumber}&Params.PyPayrollTypeName={PyPayrollTypeName}";
    }
}
