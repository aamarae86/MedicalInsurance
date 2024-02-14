namespace ERP.Helpers.Core.__PostAudited
{
    public interface IAuditedStringDates
    {
        string CreationTimeStr { get; }
        string LastModificationTimeStr { get; }
        string PostedTimeStr { get; }
        string UnPostedTimeStr { get; }
    }
}
