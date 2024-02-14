using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Helpers.Parameters;

namespace ERP._System._ArSecurityDepositInterface.Dto
{
    [AutoMap(typeof(ArSecurityDepositInterface))]
    public class ArSecurityDepositInterfaceDto : AuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string SecurityDepositInterfaceNumber { get; set; }

        public decimal? Amount { get; set; }

        public string Notes { get; set; }

        public decimal? FineAmount { get; set; }

        public long? StatusLkpId { get; set; }

        public long? ArCustomerId { get; set; }

        public long? FineAccountId { get; set; }
         
        public long? SourceCodeLkpId { get; set; }

        public string SourceNo { get; set; }

        public long? SourceId { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public GlCodeComDetailsDto GlCodeComDetails { get; set; }

        public ArCustomersDto ArCustomers { get;  set; }

        public FndLookupValuesDto FndStatusLkp { get;  set; }

        public FndLookupValuesDto FndSourceCodeLkp { get;  set; }
    }
}
