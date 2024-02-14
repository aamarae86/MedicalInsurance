using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmSupervisors.Dto
{
    [AutoMap(typeof(TmSupervisors))]
    public class TmSupervisorsEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string SupervisorName { get; set; }

        public long? StatusLkpId { get; set; }
    }
}
