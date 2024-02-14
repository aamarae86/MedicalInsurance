namespace ERP._System.__Settings._FndLookupValues.Dto
{
    public class FndLookupValuesSearchDto
    {
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string LookupCode { get; set; }

        public string LookupType { get; set; }

        public override string ToString() => $"?LookupCode={LookupCode}&LookupType={LookupType}&NameAr={NameAr}&NameEn={NameEn}";
    }
}
