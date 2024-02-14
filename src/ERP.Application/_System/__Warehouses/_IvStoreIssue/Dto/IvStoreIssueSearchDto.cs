using System;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssueSearchDto
    {
        public string StoreIssueDate { get; set; }
        public string StoreIssueNumber { get; set; }
        public long? IvWarehouseId { get; set; }
        public long? StatusId { get; set; }
        public override string ToString()
        {
            return $"Params.StoreIssueNumber={StoreIssueNumber}&Params.StatusId={StatusId}&Params.IvWarehouseId={IvWarehouseId}&Params.StoreIssueDate={StoreIssueDate}";
        }
    }
}
