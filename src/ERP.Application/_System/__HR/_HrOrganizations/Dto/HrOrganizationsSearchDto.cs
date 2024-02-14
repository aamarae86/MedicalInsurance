namespace ERP._System.__HR._HrOrganizations.Dto
{
    public class HrOrganizationsSearchDto
    {
        public string OrganizationName { get; set; }

        public long? OrganizationTypeLkpId { get; set; }

        public override string ToString()
            => $"Params.OrganizationName={OrganizationName}&Params.OrganizationTypeLkpId={OrganizationTypeLkpId}";
    }
}
