namespace ERP._System.__CRM._CrmProducts.Dto
{
    public class CrmProductsSearchDto
    {
        
        public string ProductName { get; set; }

        public override string ToString()
            => $"Params.ProductName={ProductName}";
    }
}
