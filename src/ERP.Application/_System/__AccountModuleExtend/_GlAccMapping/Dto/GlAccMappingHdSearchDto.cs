namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    public class GlAccMappingHdSearchDto
    {
        public string MapName { get; set; }

        public string MapNumber { get; set; }

        public override string ToString() => $"Params.MapName={MapName}&Params.MapNumber={MapNumber}";
    }
}
