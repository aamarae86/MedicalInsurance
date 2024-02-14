namespace ERP._System.__CRM._ActivityTasks.Dto
{
    public class ActivityTasksSearchDto
    {
        public long? RelatedToLkpId { get; set; }
        public long? CrmLeadsPersonsId { get; set; }
        public string Subject { get; set; }
        public string Lang { get; set; }

        public override string ToString() => $"Params.RelatedToLkpId={RelatedToLkpId}&Params.CrmLeadsPersonsId={CrmLeadsPersonsId}&Params.Lang={Lang}&" +
            $"&Params.Subject={Subject}";
    }
}
