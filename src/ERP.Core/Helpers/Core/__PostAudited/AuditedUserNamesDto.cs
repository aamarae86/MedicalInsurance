namespace ERP.Helpers.Core.__PostAudited
{
    public class AuditedUserNamesDto : ICreatorUserName, IPostUserName, IUpdatedUserName
    {
        public string CreatedBy { get; set; }
        public string PostedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string UnPostedBy { get; set; }
    }
}
