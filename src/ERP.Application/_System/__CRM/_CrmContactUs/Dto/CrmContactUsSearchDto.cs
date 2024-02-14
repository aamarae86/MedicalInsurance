namespace ERP._System.__CRM._CrmContactUs.Dto
{
    public class CrmContactUsSearchDto
    {
        public string HeaderNameAr { get; set; }

        public string HeaderNameEn { get; set; }

        public string Email { get; set; }

        public override string ToString() => $"Params.HeaderNameAr={HeaderNameAr}&Params.HeaderNameEn={HeaderNameEn}&Params.Email={Email}";
    }
}
