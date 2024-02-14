using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto
{
    [AutoMap(typeof(PmPropertiesUnitsAttachments))]
    public class PmPropertiesUnitsAttachmentsDto : AttachEntity, IDetailRowStatus
    {
        public long PmPropertiesUnitstId { get; set; }
 
        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
