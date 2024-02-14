namespace ERP._System._TenantFreeModules.Dto
{
    public class TenantFreeModulesSearchDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreatedDate { get; set; }
        public string Lang { get; set; }
        public override string ToString() => $"Params.Name={Name}&Params.Phone={Phone}&" +
            $"&Params.Email={Email}" +
            $"&Params.CreatedDate={CreatedDate}";
    }
}
