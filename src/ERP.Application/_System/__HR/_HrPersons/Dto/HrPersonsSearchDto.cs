namespace ERP._System.__HR._HrPersons.Dto
{
    public class HrPersonsSearchDto
    {
        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string HireDate { get; set; }

        public string AccountNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        public override string ToString()
           => $"Params.EmployeeNumber={EmployeeNumber}&Params.NationalityLkpId={NationalityLkpId}&Params.StatusLkpId={StatusLkpId}&Params.HireDate={HireDate}&Params.AccountNumber={AccountNumber}&Params.FirstName={FirstName}";
    }
}
