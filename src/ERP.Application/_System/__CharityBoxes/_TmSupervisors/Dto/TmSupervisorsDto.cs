using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmSupervisors.Dto
{
    [AutoMap(typeof(TmSupervisors))]
    public class TmSupervisorsDto : AuditedEntityDto<long>
    {
        [MaxLength(30)]
        public string SupervisorNumber { get; set; }

        [MaxLength(200)]
        public string SupervisorName { get; set; }

        public long? SourceLkpId { get; set; }

        public long? StatusLkpId { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }
    }
}
