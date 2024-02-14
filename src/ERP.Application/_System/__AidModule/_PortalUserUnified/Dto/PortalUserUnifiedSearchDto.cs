namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedSearchDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string CaseNumber { get; set; }

        public string EmailAddress { get; set; }

        public bool? IsActive { get; set; }

        public string FullName { get; set; }

        public long? GenderLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public long? NationalityLkpId { get; set; }

        public string IdNumber { get; set; }

        public string PhoneNumber { get; set; }

        public long? SourceId { get; set; }

        public long? CreatorId { get; set; }

        public long? CaseCategoryLkpId { get; set; }

        public override string ToString()
            => $"Params.Name={Name}&Params.CaseNumber={CaseNumber}&Params.CaseCategoryLkpId={CaseCategoryLkpId}&Params.SourceId={SourceId}&Params.CreatorId={CreatorId}&Params.ToDate={ToDate}&Params.FromDate={FromDate}&Params.PhoneNumber={PhoneNumber}&Params.IdNumber={IdNumber}&Params.GenderLkpId={GenderLkpId}&Params.CityLkpId={CityLkpId}&Params.NationalityLkpId={NationalityLkpId}";
    }
}
