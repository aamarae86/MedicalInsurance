namespace ERP._System._Portal.Stored.Dto
{
    public class DashboardOutput
    {
        public int TotalRequests { get; set; }
        public int AcceptedRequests { get; set; }
        public int DelayedRequests { get; set; }
        public int RefusedRequests { get; set; }
    }
}
