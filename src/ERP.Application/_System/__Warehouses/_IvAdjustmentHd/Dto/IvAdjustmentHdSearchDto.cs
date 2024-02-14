namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    public class IvAdjustmentHdSearchDto
    {
        public string AdjustmentNumber { get;  set; }
        public string AdjustmentDate { get;  set; }
        public long? IvWarehouseId { get;  set; }
        public long? AdjustmentTypeLkpId { get;  set; }
        public long? StatusLkpId { get;  set; }
        
        public override string ToString() 
            => $"Params.AdjustmentNumber={AdjustmentNumber}&Params.StatusLkpId={StatusLkpId}&Params.AdjustmentDate={AdjustmentDate}&Params.AdjustmentTypeLkpId={AdjustmentTypeLkpId}&Params.IvWarehouseId={IvWarehouseId}";
    }
}
