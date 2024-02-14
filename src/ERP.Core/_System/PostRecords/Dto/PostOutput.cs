namespace ERP._System.PostRecords.Dto
{
    public class PostOutput
    {
        public string FinalStatues { get; set; }

        public string Reason { get; set; }
    }

    public class PostOutputWithId : PostOutput
    {
        public long Id { get; set; }
    }
}
