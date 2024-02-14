using System.Collections.Generic;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssueDto : IvStoreIssueBaseDto
    {
        public string StoreIssueNumber { get; set; }

        public string StatusAr { get; set; }
        public string StatusEn { get; set; }

        public string IvWarehouseName { get; set; }
        public string IvWarehouseNumber { get; set; }

        public string BeneficiaryTypeEn { get; set; }
        public string BeneficiaryTypeAr { get; set; }

        public string IssueTypeEn { get; set; }
        public string IssueTypeAr { get; set; }

        public ICollection<IvStoreIssueDetailsDto> IvStoreIssueTrs { get; set; }
    }
}
