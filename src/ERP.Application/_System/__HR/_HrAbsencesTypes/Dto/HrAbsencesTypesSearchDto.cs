namespace ERP._System.__HR._HrAbsencesTypes.Dto
{
    public class HrAbsencesTypesSearchDto
    {
        public string VacationsTypeNumber { get;  set; }

        public string VacationsTypeName { get;  set; }

        public override string ToString() => $"Params.VacationsTypeNumber={VacationsTypeNumber}&Params.VacationsTypeName={VacationsTypeName}";
    }
}
