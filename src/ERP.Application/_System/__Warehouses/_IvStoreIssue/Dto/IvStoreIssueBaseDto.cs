using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssueBaseDto : PostAuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string StoreIssueDate { get; set; }

        public long StatusLkpId { get; set; }

        public long IssueTypeLkpId { get; set; }

        public long BeneficiaryTypeLkpId { get; set; }

        public long IvWarehouseId { get; set; }

        public string BeneficiaryName { get; set; }

        public string ManualNo { get; set; }

        public string Comment { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public long AccountId { get; set; }
    }
}
