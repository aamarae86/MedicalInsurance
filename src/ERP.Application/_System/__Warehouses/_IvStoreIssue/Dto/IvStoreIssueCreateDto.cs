using Abp.AutoMapper;
using System.Collections.Generic;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    [AutoMap(typeof(IvStoreIssueHd))]
    public class IvStoreIssueCreateDto : IvStoreIssueBaseDto
    {
        public string StoreIssueNumber { get; set; }

        public ICollection<IvStoreIssueDetailsCreateDto> ListOfCreateDetails { get; set; }
    }
}
