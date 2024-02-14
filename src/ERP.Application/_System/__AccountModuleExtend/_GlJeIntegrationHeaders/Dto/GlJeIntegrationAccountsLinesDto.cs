using Abp.AutoMapper;
using ERP.Helpers.Parameters;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    [AutoMap(typeof(GlJeIntegrationLines))]
    public class GlJeIntegrationAccountsLinesDto : GlJeIntegrationLinesBaseDto, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string AccountNumber { get; set; }
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

        public string Lang { get; set; }

        public GlJeIntegrationAccountsLinesDto()
        {

        }
    }
}
