namespace ERP._System.__Warehouses._IvItemsTypesConfigure.Dto
{
    public class IvItemsTypesConfigureSearchDto
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string ConfigureCode { get; set; }

        public override string ToString() => $"Params.NameEn={NameEn}&Params.NameAr={NameAr}&Params.ConfigureCode={ConfigureCode}";
    }
}
