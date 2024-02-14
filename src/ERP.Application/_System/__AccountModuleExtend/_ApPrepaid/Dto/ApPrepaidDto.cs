using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;

namespace ERP._System.__AccountModuleExtend._ApPrepaid.Dto
{
    [AutoMap(typeof(ApPrepaid))]
    public class ApPrepaidDto : PostAuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }
        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }
        public string codeComUtilityIds_alt2 { get; set; }
        public string codeComUtilityTexts_alt2 { get; set; }
        public string codeComUtilityIds_alt3 { get; set; }
        public string codeComUtilityTexts_alt3 { get; set; }

        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string SourceNo { get; set; }

        public string TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public long? DrAccountId { get; set; }

        public long? CrAccountId { get; set; }

        public long? SourceId { get; set; }

        public long StatusLkpId { get; set; }

        public long SourceCodeLkpId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndSourceCodeLkp { get; set; }

        public GlCodeComDetailsDto DrGlCodeComDetails { get; set; }

        public GlCodeComDetailsDto CrGlCodeComDetails { get; set; }

    }
}
