using Abp.Domain.Entities;
namespace ERP._System.__ReportsAccounts.Inputs
{
    public class GlAccountSelectionInput : IMustHaveTenant
    {
        public int SEQ { get; set; }

        public string FLEX_FIELD { get; set; }

        public string ACC_TYPE { get; set; }

        public string FromValue { get; set; }

        public string ToValue { get; set; }

        public string YesNo { get; set; }

        public long User_ID { get; set; }

        public int TenantId { get; set; }
    }
}
