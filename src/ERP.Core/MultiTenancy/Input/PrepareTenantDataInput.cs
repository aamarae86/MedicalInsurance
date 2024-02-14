namespace ERP.MultiTenancy.Input
{
    public class PrepareTenantDataInput
    {
        public int TenantId { get; set; }
        public long IndustryLkpId { get; set; }
        public long UserId { get; set; }
    }
}
