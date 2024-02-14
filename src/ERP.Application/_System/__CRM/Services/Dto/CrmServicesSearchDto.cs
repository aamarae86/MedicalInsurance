namespace ERP._System.__CRM._CrmServices.Dto
{
    public class CrmServicesSearchDto
    {
        
        public string ServiceName { get; set; }

        public override string ToString()
            => $"Params.ServiceName={ServiceName}";
    }
}
