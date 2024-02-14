using Abp.Domain.Entities;


namespace ERP._System.__ReportsAccounts.Inputs
{
    public class GlAccountSelectionDeleteInput : IMustHaveTenant
    {
        public long User_ID { get; set; }

        public int TenantId { get; set; }
    }
}
