using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmTenantsAttachments;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using static ERP.Helpers.Core.DetailRowStatus;

namespace ERP._System.__PmPropertiesModule._PmTenants.Dto
{
    [AutoMap(typeof(PmTenantsAttachments))]
    public class PmTenantsAttachmentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long PmTenantId { get; set; }

        public PmTenantsDto PmTenant { get; set; }

        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; set; }

        [MaxLength(1000)]
        public string FilePath { get; set; }

        public string rowStatus { get; set; } = RowStatus.NoAction.ToString();
    }
}
