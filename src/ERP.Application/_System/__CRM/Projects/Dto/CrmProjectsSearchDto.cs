namespace ERP._System.__CRM._CrmProjects.Dto
{
    public class CrmProjectsSearchDto
    {
        public string ProjectDate { get; set; }
        public string ProjectName { get; set; }

        public override string ToString()
            => $"Params.ProjectName={ProjectName}&Params.ProjectDate={ProjectDate}";
    }
}
