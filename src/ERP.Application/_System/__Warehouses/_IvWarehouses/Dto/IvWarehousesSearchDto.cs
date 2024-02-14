namespace ERP._System.__Warehouses.Dto
{
    public class IvWarehousesSearchDto
    {
        public string WarehouseNumber { get; set; }

        public string WarehouseName { get; set; }

        public long? CityLkpId { get; set; }

        public override string ToString() => $"Params.WarehouseNumber={WarehouseNumber}&Params.WarehouseName={WarehouseName}&Params.CityLkpId={CityLkpId}";
    }
}
