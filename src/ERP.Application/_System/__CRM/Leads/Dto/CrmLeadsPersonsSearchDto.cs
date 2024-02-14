namespace ERP._System.__CRM._CrmLeadsPersons.Dto
{
    public class CrmLeadsPersonsSearchDto
    {
        public string FullName { get; set; }
        public int? IsLead { get; set; }
        public string Phone { get; set; }
        public long? RatingLkpId { get; set; }
        public string City { get; set; }
        public long? CountryLkpId { get; set; }
        public string Company { get; set; }
        public long? LeadSourceLkpId { get; set; }
        public long? IndustryLkpId { get; set; }
        public string State { get; set; }
        public string Lang { get; set; }
        public long? CrmProductId { get; set; }
        public long? CrmServiceId { get; set; }
        public string ActivityType { get; set; }
        public string Email { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long? UserId { get; set; }
        public string CreatedDate { get; set; }
        public long? CallResultLkpId { get; set; }

        public override string ToString() => $"Params.FullName={FullName}&Params.Phone={Phone}&" +
            $"&Params.RatingLkpId={RatingLkpId}" +
            $"&Params.CountryLkpId={CountryLkpId}" +
            $"&Params.Company={Company}" +
            $"&Params.LeadSourceLkpId={LeadSourceLkpId}" +
            $"&Params.IndustryLkpId={IndustryLkpId}" +
            $"&Params.Lang={Lang}" +
            $"&Params.State={State}" +
            $"&Params.IsLead={IsLead}" +
            $"&Params.City={City}"+
            $"&Params.CrmProductId={CrmProductId}" +
            $"&Params.CrmServiceId={CrmServiceId}"+
            $"&Params.Email={Email}" +
            $"&Params.FromDate={FromDate}" +
            $"&Params.ToDate={ToDate}" +
            $"&Params.ActivityType={ActivityType}" +
            $"&Params.UserId={UserId}" + $"&Params.CallResultLkpId={CallResultLkpId}" +
            $"&Params.CreatedDate={CreatedDate}" ;
    }
}
