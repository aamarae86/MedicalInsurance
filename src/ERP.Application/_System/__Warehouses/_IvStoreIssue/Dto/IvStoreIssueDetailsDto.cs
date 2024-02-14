using Abp.AutoMapper;
using System;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    [AutoMapFrom(typeof(IvStoreIssueTr))]
    public class IvStoreIssueDetailsDto : IvStoreIssueDetailsBaseDto
    {
        public string IvItemNumber { get; set; }
        public string IvItemName { get; set; }

        public string IvUnitName { get; set; }
    }
}
