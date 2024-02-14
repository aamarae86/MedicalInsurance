namespace ERP.Users.Dto
{
    public class NotificationSearchDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }
        
        public int? State { get; set; }

        public string Message { get; set; }

        public override string ToString()
            => $"Params.Message={Message}&Params.State={State}&Params.ToDate={ToDate}&Params.FromDate={FromDate}";
    }
}
