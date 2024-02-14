using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using ERP.Helpers.Parameters;

namespace ERP._System._GlMainAccounts.Dto
{
    [AutoMap(typeof(GlMainAccounts))]
    public class GlMainAccountsDto : AuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts, IPassivable
    {
        public long? AccountId { get; set; }

        public string ReferenceCode { get; set; }

        public string Description { get; set; }

        public string NameArDetails { get; set; }

        public string NameEnDetails { get; set; }

        public string CodesDetails { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

        public bool IsActive { get; set; }
    }
}
