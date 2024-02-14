using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Parameters;
using System.Collections.Generic;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    [AutoMap(typeof(IvStoreIssueHd))]
    public class IvStoreIssueEditDto : EntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string StoreIssueDate { get; set; }

        public long IssueTypeLkpId { get; set; }

        public long BeneficiaryTypeLkpId { get; set; }

        public long IvWarehouseId { get; set; }

        public string BeneficiaryName { get; set; }

        public string ManualNo { get; set; }

        public string Comment { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public long AccountId { get; set; }

        public ICollection<IvStoreIssueDetailsEditDto> ListOfEditDetails { get; set; }
    }
}
