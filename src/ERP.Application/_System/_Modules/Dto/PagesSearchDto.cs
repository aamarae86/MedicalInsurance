namespace ERP._System._Modules.Dto
{
    public class PagesSearchDto
    {
        public int? ModuleId { get; set; }

        public override string ToString() => $"Params.ModuleId={ModuleId}";
    }
}
