using Abp.Domain.Entities.Auditing;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class SpBeneficentVM : AuditedEntity<long>
    {
        public string BeneficentNumber { get; set; }

        public string BeneficentName { get; set; }

    }
}